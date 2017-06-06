#tool "nuget:?package=GitVersion.CommandLine"

var target        = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var solution      = "./GitRelease.sln";

Task("Clean")
    .Does(() =>
{
    CleanDirectories(string.Format("./src/**/obj/{0}", configuration));
    CleanDirectories(string.Format("./src/**/bin/{0}", configuration));
});

Task("RestorePackages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solution);
});

Task("Build")
    .IsDependentOn("RestorePackages")
    .Does(() =>
{
    MSBuild(solution, settings => settings
        .SetConfiguration(configuration)
        .SetVerbosity(Verbosity.Minimal)
        .UseToolVersion(MSBuildToolVersion.VS2017)
    );
});

Task("UpdateAssemblyInfo")
    .Does(() =>
{
    GitVersion(new GitVersionSettings {
        UpdateAssemblyInfo = true
    });
});

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);