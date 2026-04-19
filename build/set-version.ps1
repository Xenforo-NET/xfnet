param(
    [Parameter(Mandatory = $true)]
    [string]$Version
)

$ErrorActionPreference = "Stop"

if ($Version -notmatch '^\d+\.\d+\.\d+$')
{
    throw "Version must be in Major.Minor.Patch format."
}

$root = Split-Path -Parent $PSScriptRoot
$assemblyInfo = Join-Path $root "src\XenForoSharp\Properties\AssemblyInfo.cs"
$versionParts = $Version.Split(".")
$assemblyVersion = "{0}.{1}.{2}.0" -f $versionParts[0], $versionParts[1], $versionParts[2]

$content = Get-Content $assemblyInfo -Raw
$content = [regex]::Replace($content, 'AssemblyVersion\(\"[^\"]+\"\)', 'AssemblyVersion("' + $assemblyVersion + '")')
$content = [regex]::Replace($content, 'AssemblyFileVersion\(\"[^\"]+\"\)', 'AssemblyFileVersion("' + $assemblyVersion + '")')
Set-Content -Path $assemblyInfo -Value $content -Encoding UTF8
