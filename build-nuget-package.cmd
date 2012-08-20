@echo off
echo Updating package sources...
copy /y .\src\TinyTwitter\TinyTwitter.cs .\nuget\content\
echo Creating package...
.\tools\NuGet.exe Pack .\nuget\Package.nuspec -OutputDirectory .
echo Package generated!
pause