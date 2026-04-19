param(
    [string]$Configuration = "Release",
    [string]$Version = "1.0.0"
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$solution = Join-Path $root "src\xfnet.sln"
$nuspec = Join-Path $root "src\xfnet\xfnet.nuspec"
$artifacts = Join-Path $root "artifacts"

$msbuildCandidates = @(
    "C:\Program Files\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe",
    "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe",
    "C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe",
    "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"
)

$msbuild = $msbuildCandidates | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $msbuild)
{
    throw "MSBuild was not found."
}

$nugetCandidates = @(
    (Get-Command nuget.exe -ErrorAction SilentlyContinue | Select-Object -First 1).Source,
    "C:\nuget.exe"
) | Where-Object { $_ -and (Test-Path $_) } | Select-Object -Unique

$nuget = $nugetCandidates | Select-Object -First 1
if (-not $nuget)
{
    throw "nuget.exe was not found in PATH or at C:\nuget.exe."
}

New-Item -ItemType Directory -Force -Path $artifacts | Out-Null

& $nuget restore $solution
if ($LASTEXITCODE -ne 0)
{
    throw "NuGet restore failed."
}

& $msbuild $solution /t:Build /p:Configuration=$Configuration
if ($LASTEXITCODE -ne 0)
{
    throw "Build failed."
}

& $nuget pack $nuspec -BasePath $root -OutputDirectory $artifacts -Properties "configuration=$Configuration;version=$Version" -NoPackageAnalysis
if ($LASTEXITCODE -ne 0)
{
    throw "NuGet pack failed."
}
