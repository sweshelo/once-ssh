$build = dotnet publish -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true;
$out = $build[$build.Length-1].trim().split()
cp "$($out[2])$($out[0]).exe" "$(pwd)/$($out[0]).exe"