dotnet new sln --name School.Web


dotnet new webapi --auth none -o School.WebApi


dotnet new classlib -o School.Domain
dotnet new classlib -o School.Repository


dotnet sln add School.Domain\School.Domain.csproj
dotnet sln add School.Repository\School.Repository.csproj
dotnet sln add School.WebApi\School.WebApi.csproj


dotnet add School.Repository\School.Repository.csproj reference School.Domain\School.Domain.csproj
dotnet add School.WebApi\School.WebApi.csproj reference School.Domain\School.Domain.csproj
dotnet add School.WebApi\School.WebApi.csproj reference School.Repository\School.Repository.csproj


dotnet add School.Repository\School.Repository.csproj package Pomelo.EntityFrameworkCore.MySql
dotnet add School.Repository\School.Repository.csproj package Microsoft.EntityFrameworkCore.Tools

dotnet tool install --global dotnet-ef

start angular.bat

ng new Views
pause
npm install bootstrap --save
npm i @fortawesome/fontawesome-free --save 
npm install ngx-bootstrap --save