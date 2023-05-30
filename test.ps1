# Run the end to end tests. The tests can't have project references to Vogen. This is because, in Visual Studio, 
# it causes conflicts caused by the difference in runtime; VS uses netstandard2.0 to load and run the analyzers, but the 
# test project uses a variety of runtimes. So, it uses NuGet to reference the Vogen analyzer. To do this, this script first 
# builds and packs Vogen using a ridiculously high version number and then restores the tests NuGet dependencies to use that
# package. This will allow you run and debug debug these tests in VS, but to use any new code changes in the analyzer, you 
# need to rerun this script to force a refresh of the package. 

$artifacts = "$PSScriptRoot\artifacts"
$localPackages = "$PSScriptRoot\local-global-packages"

function WriteStage([string]$message)
{
    Write-Host "############################################" -ForegroundColor Cyan
    Write-Host "**** " $message -ForegroundColor Cyan
    Write-Host "############################################" -ForegroundColor Cyan
    Write-Output ""
}

function Get999VersionWithUniquePatch()
{
    $date1 = Get-Date("2022-10-17");
    $date2 = Get-Date;
    $patch = [int64]((New-TimeSpan -Start $date1 -End $date2)).TotalSeconds
    return "999.9." + $patch;
}

if(Test-Path $artifacts) { Remove-Item $artifacts -Force -Recurse }

New-Item -Path $artifacts -ItemType Directory

New-Item -Path $localPackages -ItemType Directory -ErrorAction SilentlyContinue

Remove-Item $localPackages\vogen.* -Force

$version = Get999VersionWithUniquePatch



dotnet restore Vogen.sln --packages $localPackages --no-cache
dotnet clean Vogen.sln

# Build **just** Vogen first to generate the NuGet package. In the next step,
# we'll build the consumers of package, namely the e2e tests and samples projects.

# **NOTE** - we don't want these 999.9.9.x packages ending up in %userprofile%\.nuget\packages because it'll polute it.

WriteStage("Packing the Vogen NuGet package version " +$version + " into " + $localPackages)


dotnet pack Vogen.sln -c Debug /p:PackageOutputPath=$localPackages /p:ForceVersion=$version --include-symbols --version-suffix:dev --no-restore

# Restore the project using the custom config file, restoring packages to a local folder
dotnet restore ./tests/ConsumerTests -p UseLocallyBuiltPackage=true --force --no-cache --packages $localPackages --configfile: ./nuget.private.config

dotnet restore ./Samples/Vogen.Examples -p UseLocallyBuiltPackage=true --force --no-cache --packages $localPackages --configfile: ./nuget.private.config

dotnet build ./tests/ConsumerTests -c Debug --no-restore
dotnet build ./Samples/Vogen.Examples -c Debug --no-restore

dotnet test ./tests/ConsumerTests -c Debug --no-build --no-restore 


