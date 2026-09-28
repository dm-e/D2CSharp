..\bin\ExtractReworked.exe -g ..\TestsGenerated -w ..\TestsWorking -r ..\TestsReworked -d
..\bin\D2CSharp.exe
xcopy /s /y ..\TestsGenerated ..\TestsWorking
xcopy /s /y ..\TestsReworked ..\TestsWorking
call ..\D2CSharpTests\Formatting\FormatAll.cmd
Pause
