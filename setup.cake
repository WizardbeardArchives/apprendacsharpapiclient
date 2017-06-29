#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context, 
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./",
                            title: "ApprendaApiClient",
                            repositoryOwner: "Apprenda, Inc.",
                            repositoryName: "Apprenda-Api-Client");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] { BuildParameters.RootDirectoryPath + "/src/AccountPortalSwagger/**/*.cs", BuildParameters.RootDirectoryPath + "/src/DeveloperPortalSwagger/**/*.cs" },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[*.Tests]* -[FluentAssertions*]* ",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs",
                            dupFinderDiscardCost: 150,
                            dupFinderThrowExceptionOnFindingDuplicates: false);

Build.Run();
