@echo off
IF "%1"=="" GOTO ERROR
echo Updating database 
IF "%1"=="-i" (
osql -E -i installproc.sql
)

IF "%1"=="-u" (
osql -E -i removeproc.sql
)
echo Finished Updating database 
echo installing worklist server as window service
%windir%\microsoft.Net\Framework\v2.0.50727\InstallUtil.exe %1 WorklistServer.Services.exe
Goto Finished
:ERROR
echo ERROR: need to specify the parameter 
echo -i: for install service
echo -u for remove service
:Finished
pause