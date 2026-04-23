# Laboratory Work 12 - Layered Architecture

## Purpose

The purpose of this laboratory work is to organize the ASP.NET Core project into separate layers and keep responsibilities separated.

## Implemented Result

The TaskFlow solution is split into four projects:

- `TaskFlow.Domain` - domain entities and enums.
- `TaskFlow.Application` - DTOs, interfaces and business services.
- `TaskFlow.Infrastructure` - EF Core, repositories and database configuration.
- `TaskFlow.Web` - controllers, Razor Pages, middleware, filters and startup configuration.

The web project depends on the application layer and infrastructure registration. The application layer depends on domain models and repository interfaces. The infrastructure layer implements repository interfaces. This structure makes the project easier to extend.

## Main Files

- `TaskFlowWorks.sln` - solution file.
- `src/TaskFlow.Domain/TaskFlow.Domain.csproj` - domain project.
- `src/TaskFlow.Application/TaskFlow.Application.csproj` - application project.
- `src/TaskFlow.Infrastructure/TaskFlow.Infrastructure.csproj` - infrastructure project.
- `src/TaskFlow.Web/TaskFlow.Web.csproj` - web project.
- `src/TaskFlow.Web/Program.cs` - composition root.

## Architecture Rules

- Domain classes do not know about EF Core controllers or Razor Pages.
- Application services use repository interfaces.
- Infrastructure implements data access.
- Web layer handles HTTP requests and UI.
- Dependency injection connects all layers in `Program.cs`.

## How To Check

Build the solution:

```powershell
dotnet build TaskFlowWorks.sln
```

Open the project structure and check project references in each `.csproj` file.

## What This Work Proves

This work proves that the application is not written as one large web project. It follows a layered structure with clear responsibilities.

## Short Defense Text

In this laboratory work I organized the solution into domain, application, infrastructure and web layers. Each layer has its own responsibility, and dependencies are connected through interfaces and dependency injection.
