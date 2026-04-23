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

## How To Check

For this PR, check that the migration files and model snapshot exist and that the infrastructure project builds:

```powershell
dotnet build src\TaskFlow.Infrastructure\TaskFlow.Infrastructure.csproj
```

After applying the later Web API PR, the application startup also applies migrations automatically from `src/TaskFlow.Web/Program.cs`. In the full project this can be checked with:

```powershell
dotnet run --project src\TaskFlow.Web\TaskFlow.Web.csproj --urls http://localhost:5124
```

Then the seeded data can be checked through `GET /api/tasks`, `GET /api/projects` and `GET /api/tasks/report/status`.

## What This Work Proves

This work proves that the application schema is managed with migrations instead of being created manually. It also proves that the database context is integrated with ASP.NET Core dependency injection and used correctly in request processing.

## Short Defense Text

In this practical work I added EF Core migrations and configured `TaskFlowDbContext` lifecycle. The project can create the database schema automatically and update it through migrations. The context is registered as scoped and used by repositories for database operations.
