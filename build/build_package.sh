#!/bin/bash
ver=$(gitversion)
nugetVer=`echo "$ver" | jq .NuGetVersionV2 -r`
export GitVersion_NuGetVersionV2=$nugetVer
dotnet pack -c Release

