@echo off
echo Please write any name for migrations, tanks!
@set /p var=

rd /s /q school.webapi\migrations
dotnet ef database drop  --project School.webapi -f

dotnet ef migrations add %var% --project school.webapi

dotnet ef database update --project School.webapi
@Echo off
pause
Echo TA LIBERADO, PRONTO PARA TENTAR DE NOVO.
