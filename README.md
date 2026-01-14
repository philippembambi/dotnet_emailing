### Create layers
- dotnet new classlib -n First.EmailReminder.Application
- dotnet new classlib -n First.EmailReminder.Infrastructure
- dotnet new blazor -o First.EmailReminder.Presentation.UI
- dotnet new webapi -n First.EmailReminder.Presentation.Api

### Add classLib in the solution
- dotnet sln First.EmailReminder.sln add src/First.EmailReminder.Domain
- dotnet sln First.EmailReminder.sln add src/First.EmailReminder.Application
- dotnet sln First.EmailReminder.sln add src/First.EmailReminder.Infrastructure
- dotnet sln First.EmailReminder.sln add src/First.EmailReminder.Presentation/First.EmailReminder.Presentation.Api
- dotnet sln First.EmailReminder.sln add src/First.EmailReminder.Presentation/First.EmailReminder.Presentation.UI

### Add Project References
- dotnet add src/First.EmailReminder.Application/First.EmailReminder.Application.csproj reference src/First.EmailReminder.Domain/First.EmailReminder.Domain.csproj

- dotnet add src/First.EmailReminder.Infrastructure/First.EmailReminder.Infrastructure.csproj reference src/First.EmailReminder.Domain/First.EmailReminder.Domain.csproj

- dotnet add src/First.EmailReminder.Infrastructure/First.EmailReminder.Infrastructure.csproj reference src/First.EmailReminder.Application/First.EmailReminder.Application.csproj

- dotnet add src/First.EmailReminder.Presentation/First.EmailReminder.Presentation.Api/First.EmailReminder.Presentation.Api.csproj reference src/First.EmailReminder.Application/First.EmailReminder.Application.csproj

- dotnet add src/First.EmailReminder.Presentation/First.EmailReminder.Presentation.Api/First.EmailReminder.Presentation.Api.csproj reference src/First.EmailReminder.Infrastructure/First.EmailReminder.Infrastructure.csproj

### Application Packages
- dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
- dotnet add package MediatR --version 8.0.0
- dotnet add package MediatR.Extensions.Microsoft.DependencyInjection --version 8.0.0
- dotnet add package FluentValidation

### Infrastructure Packages
- dotnet add package Microsoft.EntityFrameworkCore --version 8.0.7
- dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.7
- dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.4
- dotnet add package BCrypt.Net-Next
- dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0
- dotnet add package System.IdentityModel.Tokens.Jwt

### Api Packages
- dotnet add package Microsoft.EntityFrameworkCore.Tools

### 
- dotnet ef migrations add InitialCreate -o Migrations
- dotnet ef database update

### 
- dotnet ef migrations add RenamePasswordField -o Migrations
- dotnet ef migrations add RenamePasswordToPasswordHash -o Migrations
- dotnet ef migrations add addRoleStringConversion -o Migrations
- dotnet ef migrations add setDateOfBithToDateOnly -o Migrations

### Use npm defined version
- nvm use

- dotnet add package Blazor.Bootstrap

-- sudo -u postgres psql
--create database first_email_reminder_db;
-- \c first_email_reminder_db;