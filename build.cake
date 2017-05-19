#tool "nuget:?package=NUnit.ConsoleRunner"

#addin "Apprenda.Cake"
#addin "Apprenda.Cake.MSBuild"

#load "./build/parameters.cake"

var Parameters = BuildParameters.Load(Context, BuildSystem);

Setup(context => {    
    
    Information("Running Build: {0}", Parameters.BuildInfo.GetBuildIdentifier());

    if(TeamCity.IsRunningOnTeamCity)
    {    
        TeamCity.SetBuildNumber(Parameters.BuildInfo.GetBuildIdentifier());
    }
    
    if(TeamCity.IsRunningOnTeamCity || Parameters.ForceAssemblyInfo)
    {        
	    Information("Updating assembly info...");
        Parameters.VersionManager.UpdateAssemblyInfo(
            "./src/**/AssemblyInfo.cs", 
            Parameters.AssemblyInfoSettings
        );

        Information("Updating nuspec info");
        var nugetPacks = Parameters.GetNuGetPacks();
        foreach(var item in nugetPacks)
        {
            Information("Transforming nuspec '{0}' for version {1}...", item.GetNuspec().FullPath, item.VersionInfo.NuGetVersion);                    
            // update nuspec -- only the version.  the rest is either parameterized or defaulted to assembly metadata
            TransformNuspec(item.GetNuspec(), item.Settings, new[]{ NuspecKeys.Version });
        }
    }    
});

Task("New-Assembly-Info-Version")
    .WithCriteria(() => Context.HasArgument("NewVersion"))
    .Does(() => {
        UpdateAssemblyInfo(
            "./src/**/AssemblyInfo.cs",
            AssemblyInfoSettingsProvider.NormalizeAssemblyInfo(Parameters.BuildInfo, Context.Argument<string>("NewVersion"))
        );
    });

Task("Clean-NuGet-Packages")    
    .Does(() => {
        Information("Cleaning NuGet packages directory...");
        CleanDirectory("./packages");
    });

Task("Clean")    
	.Does(() => {
        Information("Cleaning working directory...");
		CleanDirectories("./src/**/bin");
        CleanDirectories("./src/**/obj");
		CleanDirectories("./tests/**/bin");
		CleanDirectories("./tests/**/obj");
	});

Task("Clean-All")    
    .IsDependentOn("Clean-NuGet-Packages")
    .IsDependentOn("Clean");

Task("Restore-Nuget-Packages")    
    .Does(() => {        
        Information("Restoring NuGet packages...");
		NuGetRestore(
            Parameters.SolutionFile,
            Parameters.ToNuGetRestoreSettings(true) /* always bypass the machine cache */            
        );
    });

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() => {
        MSBuild(Parameters.SolutionFile, settings =>
            // the platform target may need to be x86.
            // in many cases, the solution config is set to x86 and then redirects targets
            // to the individual projects as necessary
			settings.SetConfiguration(Parameters.Configuration).SetPlatformTarget(PlatformTarget.MSIL)
        );
    });

Task("Clean-Build")
    .IsDependentOn("Clean-All")
    .IsDependentOn("Build");    

Task("Run-Unit-Tests")
    .WithCriteria(() => Parameters.IsDebug())
    .IsDependentOn("Clean")
    .IsDependentOn("Build")
    .Does(() => {
        NUnit3("./tests/**/bin/**/*.Tests.dll");
    });

Task("Build-Artifacts")    
    .IsDependentOn("Clean-Build")
    .Does(() => {
        // clean the nuget output dir - once per config               
        var nugetOutputDir = Parameters.GetNuGetOutputDirectory();
        var teamCityOutputDir = Directory("./.teamcity").Path;

        CleanDirectory(nugetOutputDir);
		Information("Generating artifacts using configuration '{0}'...", Parameters.Configuration);
		
        foreach(var item in Parameters.GetNuGetPacks())
        {
            Information("Packing NuGet package for '{0}' at version {1}...", item.Csproj.FullPath, item.VersionInfo.NuGetVersion);
			
			// pack csproj
            NuGetPack(item.Csproj, item.Settings);

            // get the configuration-specific properties from the csproj (output dir, namely)
            var parsedProject = ParseProjectExtended(
                item.Csproj,
                ProjectParseOptions.FromArgs(Configuration => Parameters.Configuration)
            );

            Information("Copying artifacts for TeamCity...");
            CopyFiles(
                parsedProject.GetFullOutputDirectory().Glob("*.pdb"),                
                file => file.GetFilename().FullPath == parsedProject.GetAssemblyPdb(),
                BuildPath.For(teamCityOutputDir).Combine(PathSegment.FirstChildOf("src")).Combine(Parameters.Configuration)                
            );
        }       
    });

Task("Publish-Artifacts")
    .IsDependentOn("Build-Artifacts")
    .WithCriteria(() => TeamCity.IsRunningOnTeamCity)
    .Does(() => {         
        // Get the paths to the packages.
        var packages = GetFiles(Parameters.GetNuGetOutputDirectory().Glob("*.nupkg"));
        
        foreach(var item in packages)
        {
            Information("Publishing package: " + item.FullPath);
            // Push the package(s) if it doesn't exist
            NuGetPush(
                item, 
                Parameters.ToNuGetPushSettings(Parameters.NuGetOptions.ApiKey),
                new PackageExistenceNuGetPushCriteria(Context.Log).And(new ReleaseVersionExistenceNuGetPushCriteria(Context.Log))
            );
        }    
    });    

Task("Check-NuGet-Packages-Exist")
    .IsDependentOn("Build-Artifacts")
    .Does(() => {
        var packages = GetFiles(Parameters.GetNuGetOutputDirectory().Glob("*.nupkg"));
        var settings = Parameters.ToNuGetPushSettings();
        Information("Probing NuGet Source: {0}", settings.Source);
        foreach(var item in packages)
        {
            Information("Querying for package: " + item.FullPath);
            LogNuGetPackageExists(item, settings);
            LogNuGetReleasePackageExists(item, settings);
        }
    });

Task("Publish")
    .IsDependentOn("Run-Unit-Tests")
    .WithCriteria(() => Parameters.NuGetOptions.HasApiKey())    
    .Does(() => {

        CleanDirectory("./.nuget");
        CleanDirectory("./.teamcity");
        
        Parameters.Configuration = "Debug";
        RunTarget("Publish-Artifacts");
        
        Parameters.Configuration = "Release";
        RunTarget("Publish-Artifacts");
        
        if(TeamCity.IsRunningOnTeamCity || Parameters.ForceObfuscation)
        {            
            Parameters.Configuration = "Obfuscate";
            RunTarget("Publish-Artifacts");
        }
        else 
        {
            Warning("Skipping 'Obfuscate' publication step");
        }        
    });

Task("Default")
    .Does(() => {
        RunTarget("Build");        
    });

RunTarget(Parameters.Target);