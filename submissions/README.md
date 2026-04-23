# Submission Guide

This folder contains handoff notes for every laboratory and practical work in the TaskFlow ASP.NET Core project.

## Project Idea

TaskFlow is a small task management system. It is used as one continuous project for all works. Every next laboratory or practical work extends the previous one, so the final project contains:

- Entity Framework Core data access;
- database migrations;
- layered architecture;
- Web API controllers;
- DTO models and validation;
- Swagger/OpenAPI documentation;
- middleware and filters;
- Razor Pages UI;
- logging and caching support;
- demo authentication and authorization.

## Why The Source Code Is Shared

The source code is stored in `../src` because the works are connected. For example, the UI work needs the API, services and database that were created earlier. Each folder in `submissions` explains what part of the shared project belongs to a specific assignment.

## Pull Request Structure

The recommended submission format is one branch and one pull request per assignment:

1. `practical-09-ef-core-sql`
2. `practical-10-migrations-dbcontext`
3. `lab-10-orm-app`
4. `practical-11-web-api-json-di`
5. `lab-11-web-api-dto-swagger`
6. `practical-12-ef-middleware`
7. `lab-12-layered-architecture`
8. `practical-13-exception-filters`
9. `lab-13-ui-web-app`
10. `practical-14-swagger-validation-routing`
11. `lab-14-logging-caching`
12. `practical-15-razor-pages`
13. `practical-16-architecture-logging-cache`
14. `practical-17-auth-roles-claims`

The branches are intended to be reviewed in this order. Each next branch continues the previous one.

## How To Run The Project

Restore and build:

```powershell
dotnet restore TaskFlowWorks.sln
dotnet build TaskFlowWorks.sln
```

Run the web application:

```powershell
dotnet run --project src\TaskFlow.Web\TaskFlow.Web.csproj --urls http://localhost:5124
```

## Main Demo Pages

- Main work overview: `http://localhost:5124/Works`
- Razor UI: `http://localhost:5124/Tasks`
- Swagger UI: `http://localhost:5124/swagger`
- OpenAPI JSON: `http://localhost:5124/openapi/v1.json`

## Database

The project uses SQLite by default for local development. The database is created automatically when the application starts because migrations are applied in `Program.cs`.

The infrastructure layer also contains SQL Server provider configuration, so the database provider can be changed through application settings.

## What To Attach In Classroom

For every assignment, attach the corresponding pull request link. Example:

```text
Practical Work 9:
https://github.com/kertes7/aspnet-task/pull/1

Laboratory Work 10:
https://github.com/kertes7/aspnet-task/pull/3
```

Each assignment folder contains:

- assignment topic;
- implemented functionality;
- main files to show;
- demo URLs;
- short defense text.
