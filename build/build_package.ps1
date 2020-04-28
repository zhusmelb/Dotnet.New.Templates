if (Test-Path env:GitVersion_NuGetVersionV2) {
    Remove-Item env:GitVersion_NuGetVersionV2
}
$GitVersion_NuGetVersionV2 = (GitVersion.exe |  jq .NuGetVersionV2 -r)
New-Item -Path Env: -Name GitVersion_NuGetVersionV2 -Value $GitVersion_NuGetVersionV2 | Out-Null
& dotnet.exe pack
Remove-Item env:GitVersion_NuGetVersionV2