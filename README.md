# RepositoryPattern
The Repository pattern adds a separation layer between the data and domain layers of an application

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

Database: Postgres SQL

Target Framwork: .Net core 3.1 (long time support)

Command: 
- cd RepositoryPattern
- dotnet ef database update init-tbl

Global exception:
- Handle business logic exception
- context exception

Api Response: 
- Success 
- Failed

Log:
- Write log txt

