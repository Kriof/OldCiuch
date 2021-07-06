for %%a in ("%~dp0\.") do set "parent=%%~nxa"
echo %parent%
RMDIR "Migrations" /S /Q
dotnet ef migrations add %parent%
dotnet ef database update
pause