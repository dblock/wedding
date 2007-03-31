@echo off
pushd "%~dp0"
setlocal

set PROJECTNAME=Wedding
set TARGET=%~dp0%PROJECTNAME%
echo Creating %TARGET% ...
if EXIST "%TARGET%" ( rd /s/q "%TARGET%" )

echo Copying Web
xcopy /S /I "%~dp0..\Web.Deploy\Release\*.*" "%TARGET%"
rem echo Copying Sql
rem mkdir "%TARGET%\sql"
rem copy "%~dp0..\Database\*.*" "%TARGET%\sql"

if EXIST %PROJECTNAME%.zip del %PROJECTNAME%.zip
bin\zip32 -r %PROJECTNAME%.zip %PROJECTNAME%\*.*

endlocal
popd
