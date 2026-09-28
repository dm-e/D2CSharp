@echo off
setlocal

pushd "%~dp0"

echo Formatting TestsGenerated...
dotnet format GeneratedFormatting.csproj whitespace --no-restore

if errorlevel 1 (
    echo.
    echo Formatting TestsGenerated failed.
    popd
    exit /b 1
)

echo.
echo Formatting TestsWorking...
dotnet format WorkingFormatting.csproj whitespace --no-restore

if errorlevel 1 (
    echo.
    echo Formatting TestsWorking failed.
    popd
    exit /b 1
)

echo.
echo Both directories were formatted successfully.

popd
exit /b 0
