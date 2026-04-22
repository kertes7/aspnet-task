# Practical Work 10 - EF Core Migrations and DbContext

## Purpose

The purpose of this practical work is to show how Entity Framework Core migrations are used to create and update a database schema. The work also demonstrates correct `DbContext` registration and usage in an ASP.NET Core application.

## Implemented Result

The project contains EF Core migrations in the infrastructure layer. The first migration creates the initial database structure with users, projects, tasks and comments. The second migration demonstrates model evolution by adding a project code field and a unique index.

`TaskFlowDbContext` is registered through dependency injection. The context is used as a scoped service, which means every HTTP request receives its own context instance. Repository methods use asynchronous EF Core operations and call `SaveChangesAsync` for create, update and delete operations.

## Main Files

- `src/TaskFlow.Infrastructure/TaskFlowDbContext.cs` - entity mappings, relations and seed data.
- `src/TaskFlow.Infrastructure/Migrations/20260422164414_InitialCreate.cs` - initial schema migration.
- `src/TaskFlow.Infrastructure/Migrations/20260422170510_AddProjectCodeAndProjectCrud.cs` - schema update migration.
- `src/TaskFlow.Infrastructure/Migrations/TaskFlowDbContextModelSnapshot.cs` - current EF Core model snapshot.
- `src/TaskFlow.Infrastructure/ServiceCollectionExtensions.cs` - `DbContext` registration.
- `src/TaskFlow.Web/Program.cs` - migration execution on application startup.

## How To Check

Build the solution:

```powershell
dotnet build TaskFlowWorks.sln
```

Run the application:

```powershell
dotnet run --project src\TaskFlow.Web\TaskFlow.Web.csproj --urls http://localhost:5124
```

When the application starts, migrations are applied automatically. Then check:

- `GET http://localhost:5124/api/tasks`
- `GET http://localhost:5124/api/projects`
- `GET http://localhost:5124/api/tasks/report/status`

## What This Work Proves

This work proves that the application schema is managed with migrations instead of being created manually. It also proves that the database context is integrated with ASP.NET Core dependency injection and used correctly in request processing.

## Short Defense Text

In this practical work I added EF Core migrations and configured `TaskFlowDbContext` lifecycle. The project can create the database schema automatically and update it through migrations. The context is registered as scoped and used by repositories for database operations.
