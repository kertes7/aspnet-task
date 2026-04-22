# Practical Work 9 - Entity Framework Core and SQL

## Purpose

The purpose of this practical work is to create the first database-backed part of the ASP.NET Core project. The work demonstrates how domain entities are designed, how they are connected with Entity Framework Core, and how data can be stored in a relational database.

## Implemented Result

The TaskFlow project contains a small task management domain. It includes users, projects, work tasks and task comments. These entities are connected with one-to-many relations:

- one user can own many projects;
- one project can contain many tasks;
- one user can be assigned to many tasks;
- one task can contain many comments.

Entity Framework Core is configured in the infrastructure layer. SQLite is used for local development because it is easy to run without installing an external database server. SQL Server provider support is also available through configuration, so the project still follows the SQL database requirement.

## Main Files

- `src/TaskFlow.Domain/AppUser.cs` - user entity.
- `src/TaskFlow.Domain/Project.cs` - project entity.
- `src/TaskFlow.Domain/WorkTask.cs` - task entity.
- `src/TaskFlow.Domain/TaskComment.cs` - comment entity.
- `src/TaskFlow.Domain/WorkItemStatus.cs` - task status enum.
- `src/TaskFlow.Infrastructure/TaskFlowDbContext.cs` - EF Core database context.
- `src/TaskFlow.Infrastructure/Repositories/EfWorkTaskRepository.cs` - EF Core repository for tasks.
- `src/TaskFlow.Infrastructure/Repositories/EfProjectRepository.cs` - EF Core repository for projects.
- `src/TaskFlow.Infrastructure/ServiceCollectionExtensions.cs` - database provider registration.

## How To Check

Run the web project:

```powershell
dotnet run --project src\TaskFlow.Web\TaskFlow.Web.csproj --urls http://localhost:5124
```

Check the data through API endpoints:

- `GET http://localhost:5124/api/tasks`
- `GET http://localhost:5124/api/projects`

The same task data can also be viewed through the Razor UI:

- `http://localhost:5124/Tasks`

## What This Work Proves

This work proves that the project has a real data model and persistent storage. The application does not keep data only in memory. The domain entities are mapped to database tables through EF Core, and repository classes use the context to query and save data.

## Short Defense Text

In this practical work I created the base database model for the TaskFlow system. The project contains related entities for users, projects, tasks and comments. Entity Framework Core is used through `TaskFlowDbContext`, and repositories provide data access for the application layer.
