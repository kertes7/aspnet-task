# Practical Work 16 - Architecture, Logging and Cache

## Purpose

The purpose of this practical work is to combine the layered architecture with logging and caching support.

## Implemented Result

The solution is organized into domain, application, infrastructure and web layers. Logging is used across the web and application layers. Memory cache is registered in the web project and can be used by services for repeated reports or lookup data.

The project follows dependency inversion: the application layer defines interfaces, and the infrastructure layer provides EF Core implementations.

## Main Files

- `src/TaskFlow.Domain` - entities and core model.
- `src/TaskFlow.Application` - DTOs, interfaces and services.
- `src/TaskFlow.Infrastructure` - EF Core and repositories.
- `src/TaskFlow.Web` - API, UI, middleware and configuration.
- `src/TaskFlow.Web/Program.cs` - dependency injection, logging and cache setup.
- `src/TaskFlow.Web/Middleware/RequestTimingMiddleware.cs` - request logs.

## Architectural Benefits

- business logic is not mixed with controllers;
- EF Core code is isolated in the infrastructure layer;
- web UI and API can reuse the same services;
- logging is centralized in middleware and filters;
- cache can be added to service methods without changing controllers.

## How To Check

Build and run:

```powershell
dotnet build TaskFlowWorks.sln
dotnet run --project src\TaskFlow.Web\TaskFlow.Web.csproj --urls http://localhost:5124
```

Open:

- `http://localhost:5124/api/tasks/report/status`
- `http://localhost:5124/Works`

## What This Work Proves

This work proves that the project is structured for extension. New features can be added to a specific layer without rewriting the whole application.

## Short Defense Text

In this practical work I demonstrated layered architecture together with logging and caching support. The project uses DI, services, repositories, middleware and memory cache registration.
