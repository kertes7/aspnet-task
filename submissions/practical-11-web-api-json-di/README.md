# Practical Work 11 - Web API, JSON and Dependency Injection

## Purpose

The purpose of this practical work is to create a Web API for the project, return JSON responses and organize dependencies through ASP.NET Core dependency injection.

## Implemented Result

The TaskFlow project exposes REST-style endpoints for tasks and projects. Controllers receive DTO objects from HTTP requests, call application services and return HTTP responses with JSON data.

Dependency injection is used for repositories, services, database context, AutoMapper, middleware, authentication and authorization components. The web layer does not manually create service classes; it receives them through constructors.

## Main Files

- `src/TaskFlow.Web/Controllers/TasksController.cs` - task API endpoints.
- `src/TaskFlow.Web/Controllers/ProjectsController.cs` - project API endpoints.
- `src/TaskFlow.Web/Program.cs` - service registration and middleware pipeline.
- `src/TaskFlow.Application/Dtos/WorkTaskDtos.cs` - task request/response models.
- `src/TaskFlow.Application/Dtos/ProjectDtos.cs` - project request/response models.
- `src/TaskFlow.Infrastructure/ServiceCollectionExtensions.cs` - infrastructure DI registration.

## API Examples

- `GET /api/tasks` - get task list.
- `GET /api/tasks/{id}` - get task details.
- `POST /api/tasks` - create a new task.
- `PUT /api/tasks/{id}` - update a task.
- `DELETE /api/tasks/{id}` - delete a task.
- `GET /api/projects` - get project list.
- `POST /api/projects` - create a project.

## How To Check

Run the project:

```powershell
dotnet run --project src\TaskFlow.Web\TaskFlow.Web.csproj --urls http://localhost:5124
```

Open Swagger:

- `http://localhost:5124/swagger`

Or call the API directly:

- `GET http://localhost:5124/api/tasks`
- `GET http://localhost:5124/api/projects`

## What This Work Proves

This work proves that the application has a structured Web API layer. JSON is used as the data exchange format, and dependencies are managed through the built-in ASP.NET Core DI container.

## Short Defense Text

In this practical work I implemented Web API controllers for the TaskFlow project. The controllers return JSON data and use services through dependency injection. The project follows the controller-service-repository structure.
