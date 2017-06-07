using Apprenda.Cake.Build;

public class BuildParameters : Apprenda.Cake.Build.BuildParametersBase
{
    const string _SolutionFile = "./ApprendaAPIClient.sln";

    public BuildParameters(ICakeContext context) : base(context) { }

    public bool ForceObfuscation { get; set; }

    public bool ForceAssemblyInfo { get; set; }

    public string SolutionFile { get; set; }

    public Func<IFile, bool> NuGetPackIgnores { get; set; }

    public Func<IFileSystemInfo, bool> NuGetPackageCleanIgnores { get; set; }
    
    public AssemblyVersionManager VersionManager { get; set; }

    public IAssemblyInfoSettingsProvider AssemblyInfoSettings { get; set; }
	
	public DirectoryPath GetNuGetOutputDirectory()
    {
        return Context.DirectoryForBuild("./.nuget/", this);
    }
	
	public List<NuGetPackInfo> GetNuGetPacks()
    {
        var nugetOutput = GetNuGetOutputDirectory();
        return Context.GetFiles("./src/**/*.csproj", NuGetPackIgnores)
                .Select(f=> {
                    var versionInfo = VersionManager.GetAssemblyInfo(f.FullPath);
                    return new NuGetPackInfo 
                    {
                        Csproj = f,
                        VersionInfo = versionInfo,
                        Settings = new NuGetPackSettings
                        {
                            Version = versionInfo.NuGetVersion,
                            OutputDirectory = nugetOutput,
                            IncludeReferencedProjects = true, /* pull in referenced projects as nugets */
                            ArgumentCustomization = args => args.Append("-Prop Configuration=" + Configuration)
                        }
                    };
                }).ToList();
    }

    public static BuildParameters Load(ICakeContext context, BuildSystem buildSystem)
    {
        if (context == null) throw new ArgumentNullException("context");
        if (buildSystem == null) throw new ArgumentNullException("buildSystem");
		
		var buildInfo = new BuildInfo(context);
        
        return new BuildParameters(context)
        {
            SolutionFile = _SolutionFile,
            Target = context.Argument("Target", "Default"),
            Configuration = context.Argument("Configuration", "Debug"),
            Platform = context.Argument("Platform", "AnyCPU"),
            ForceObfuscation = context.HasArgument("ForceObfuscation"),
            ForceAssemblyInfo = context.HasArgument("ForceAssemblyInfo"),
			BuildInfo = buildInfo,
			VersionManager = new AssemblyVersionManager(context),
            AssemblyInfoSettings = AssemblyInfoSettingsProvider.SemVer2(
                buildInfo, 
                new StoryPreReleaseNuGetPackageVersionMixin().WithCondition(MixinConditions.NotDefaultBranch)
            ),
            NuGetOptions = new NuGetPublicationOptions
            {
                ApiKey = context.Argument("ApiKey", "")
            },
            NuGetPackageCleanIgnores = (IFileSystemInfo info) => 
            { 
                var ignores = new[]
                {
                    "/Apprenda.ILMerge",
                    "/Apprenda.BuildDeploy"
                };                
                
                var item = info.Path.FullPath;                
                return !ignores.Any(s => item.Contains(s));
            },
			NuGetPackIgnores = (IFile file) => {
                var ignores = new string[]
                {
                    // we don't want to pack this project, so it's in the ignore list                    
                    "Apprenda.SomeProject.DoNotPack.csproj"
                };
                var filename = file.Path.FullPath;                
                return !ignores.Any(s=> filename.EndsWith(s, StringComparison.OrdinalIgnoreCase));
            }
        };
    }
}

public class NuGetPackInfo
{
    public FilePath Csproj { get; set;}
    public NuGetPackSettings Settings { get; set;}
    public AssemblyVersionInfo VersionInfo { get; set; }
    public FilePath GetNuspec()
    {
        return this.Csproj.ChangeExtension("nuspec");
    }
}