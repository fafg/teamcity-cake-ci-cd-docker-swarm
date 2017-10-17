#tool "nuget:?package=xunit.runner.console"

var target        = Argument("target", "Build");
var configuration = Argument("configuration", "Release");
var solution      = "../src/myapi.sln";

Task("Clean")
    .Does(() =>
{
    DotNetCoreClean(solution);
});

Task("RestorePackages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore(solution);
});

Task("Compile")
    .IsDependentOn("RestorePackages")
    .Does(() =>
{
    DotNetCoreBuild(solution);
});

Task("RunTests")
    .IsDependentOn("Compile")
    .Does(() =>
{
	DotNetCoreTest("../src/mylib.test/mylib.test.csproj");
});

Task("Build")
    .IsDependentOn("RunTests");

RunTarget(target);