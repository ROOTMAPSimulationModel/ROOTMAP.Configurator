@echo off
SET config=%1
REM Set build configuration to Debug if not specified.
IF [%1]==[] (
  SET config="Debug"
)

SET ver=%2
REM Extract version number from git tags if not specified.
IF [%2]==[] (
  FOR /F "tokens=* USEBACKQ" %%F IN (`git describe`) DO (
    SET ver=%%F
  )
)

pushd ..\ConfigurationImporter\Transformer
dotnet build --configuration %config% -p:Version=%ver%
popd
dotnet build --configuration %config% -p:Version=%ver%
dotnet publish -p:Configuration=%config% -p:Version=%ver% -p:PublishTrimmed=false -p:SelfContained=true --runtime win-x64
