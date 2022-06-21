This repository has consisted of a sample solution which explains the topics in the below list

- n-tier Architecture
- Asp.Net Core API Web API Project
- API Endpoint URL structure Best Practices
- Entity Framework Core
- Repository Service Pattern
- UnitOfWork Pattern
- AutoMapper
- Global Error Handling
- Custom Action Filter
- Authentication with JWT and role
- Support dockerize application

Database: Postgres SQL

Target Framwork: .Net core 6.0 , entity framework core

# Migrations:

Linux: 
- dotnet ef migrations add init -s Project.API -p Project.Data
- dotnet ef database update init -s Project.API -p Project.Data

Windows: 
Set start up project is Project.API and migration project is Project.Data.

Note:
- Appsetting.json: Please set polling false for development env and true for production env

Demo:

![image](https://user-images.githubusercontent.com/48196420/174226680-3d02516c-bf2e-4ad3-a6e0-e7ab6fe98bc5.png)

