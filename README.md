# WebApplicationAspNetCoreTemplate

This project building on the repository - service pattern, separation layer between the data and domain layers of an application, dependency injection, auto mapper, handle global exception, etc... 


Database: Postgres SQL

Target Framwork: .Net core 6.0 , entity framework 6

# Migrations:

Linux: 
- dotnet ef migrations add init -s Project.API -p Project.Data
- dotnet ef database update init -s Project.API -p Project.Data

Windows: 
Set start up project is Project.API and migration project is Project.Data.

Note:
- Appsetting.json: Please set polling false for development env and true for production env

Demo:

![image](https://user-images.githubusercontent.com/48196420/173294206-262217c9-6315-4f2e-aa4e-db004ff4aca9.png)


