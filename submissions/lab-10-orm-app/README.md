# Laboratory Work 10 - ORM Application

## Purpose

The purpose of this laboratory work is to create an application module that uses an ORM for real business operations. The project must show entities, relations, queries, repository logic and service logic.

## Implemented Result

The TaskFlow application uses Entity Framework Core as the ORM. The domain contains several related entities, and the infrastructure layer uses EF Core to load, filter, group and update data.

The application layer contains services that hide repository details from the web layer. Controllers and Razor Pages do not work directly with `DbContext`; they call application services. This keeps the code organized and makes the data access logic easier to test and maintain.

## Main Files

- `src/TaskFlow.Domain` - domain entities and enum.
- `src/TaskFlow.Application/Interfaces/IWorkTaskRepository.cs` - repository contract.
- `src/TaskFlow.Application/Interfaces/IWorkTaskService.cs` - service contract.
- `src/TaskFlow.Application/Services/WorkTaskService.cs` - task business logic.
- `src/TaskFlow.Application/Services/ProjectService.cs` - project business logic.
- `src/TaskFlow.Infrastructure/Repositories/EfWorkTaskRepository.cs` - ORM queries for tasks.
- `src/TaskFlow.Infrastructure/Repositories/EfProjectRepository.cs` - ORM queries for projects.

## ORM Features Used

- `Include` for loading related `Project`, `Assignee` and `Comments`.
- LINQ filtering by search text and status.
- Ordering by due date.
- Grouping tasks by status for reporting.
- Async database operations.
- Change tracking for update operations.

## How To Check

For this PR, check the service and repository code and build the application layer:

```powershell
dotnet build src\TaskFlow.Application\TaskFlow.Application.csproj
```

After applying the following Web API PR, the same ORM operations can be checked through:

- `GET /api/tasks`
- `GET /api/tasks?search=API`
- `GET /api/tasks/report/status`
- `GET /api/projects`

## What This Work Proves

This work proves that the application uses an ORM not only for table creation, but also for real application scenarios: loading related data, filtering records, grouping records and saving changes. The Web API PR that follows exposes these service operations through HTTP endpoints.

## Short Defense Text

In this laboratory work I created an ORM-backed application module. EF Core is used in repositories, and the application layer communicates with the database through services. The project demonstrates CRUD operations, relation loading and LINQ queries; the next PR exposes them through Web API controllers.
