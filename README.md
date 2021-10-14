# WebApplicationAspNetCoreTemplate
Backend: This project building on the repository pattern, separation layer between the data and domain layers of an application, dependency injection, etc... 

Package:
- Swashbuckle.AspNetCore (Swagger) Version="6.2.1"
- Npgsql.EntityFrameworkCore.PostgreSQL (5.0.10)
- Microsoft.EntityFrameworkCore.Tools (5.0.10)
- Microsoft.EntityFrameworkCore.Relational (5.0.10)
- Microsoft.EntityFrameworkCore.Design (5.0.10)
- Microsoft.EntityFrameworkCore (5.0.10)
- Microsoft.AspNetCore.SpaServices.Extensions (3.1.12)
- FluentValidation (10.3.3)
- AutoMapper.Extensions.Microsoft.DependencyInjection (8.1.1)
- AutoMapper (10.1.1) 
- FluentValidation.AspNetCore (10.3.3)

Database: Postgres SQL (You can change connection method for other DBMS at Startup.cs)

Target Framwork: .Net core 3.1 (long time support) or Net 5.0

Command: 
- cd WebApplicationAspNetCoreTemplate
- dotnet ef migrations add init-tbl (you can ignore this command)
- dotnet ef database update init-tbl (Ensure this command is executed)

Global exception:
- Handle business logic exception
- context exception

Api Response: 
- Success 
- Failed

Log:
- Write log txt

Note:
- Appsetting.json: Please set polling false for development env and true for production env

