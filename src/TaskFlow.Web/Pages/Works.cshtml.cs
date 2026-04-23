using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskFlow.Web.Pages;

public class WorksModel : PageModel
{
    public IReadOnlyList<WorkStage> Stages { get; } =
    [
        new("Practical 9", "Entity Framework Core. SQL usage",
            "Domain entities, DbContext, SQL Server provider option and CRUD repositories for tasks and projects.",
            "Domain, TaskFlowDbContext, EfWorkTaskRepository, EfProjectRepository",
            "/api/projects"),
        new("Practical 10", "Migrations and DbContext lifecycle",
            "Initial migration plus AddProjectCode migration, Database.Migrate startup flow and scoped DbContext usage.",
            "Infrastructure/Migrations, Program DI registration, CRUD update/delete flow",
            "/api/tasks/report/status"),
        new("Lab 10", "ORM application",
            "A complete data module with 4 related entities, repository, service and LINQ Include/report query.",
            "Domain entities, Application service, Infrastructure repository",
            "/api/tasks"),
        new("Practical 11", "Web API, controllers, JSON, DI",
            "API controllers with JSON endpoints using services injected through DI.",
            "Controllers/TasksController, Controllers/ProjectsController, application services",
            "/api/projects"),
        new("Lab 11", "Full Web API application",
            "DTO-based API with status codes, create/read/update/delete endpoints and Swagger UI.",
            "Dtos/WorkTaskDtos, TasksController, Program AddSwaggerGen/UseSwaggerUI",
            "/swagger"),
        new("Practical 12", "EF Core in API and middleware pipeline",
            "API works with the real database and request timing middleware logs method/path/status/time.",
            "RequestTimingMiddleware, TaskFlowDbContext, Program middleware order",
            "/api/tasks"),
        new("Lab 12", "Layered architecture",
            "Separate Domain, Application, Infrastructure and Web projects with AutoMapper DTO mapping profile.",
            "src/TaskFlow.Domain, src/TaskFlow.Application, src/TaskFlow.Infrastructure, Application/Mapping/WorkTaskProfile",
            "/Tasks"),
        new("Practical 13", "Exception handling and filters",
            "Central exception middleware and controller action logging filter with error demo endpoint.",
            "ExceptionHandlingMiddleware, ControllerLoggingFilter, /api/tasks/error-demo",
            "/api/tasks/error-demo"),
        new("Lab 13", "Web application UI",
            "Razor UI for listing, details, create, edit and delete operations against real data.",
            "Pages/Tasks/*.cshtml, Pages/Tasks/*.cshtml.cs",
            "/Tasks"),
        new("Practical 14", "Swagger, routing, model binding, validation",
            "Route/query/body binding, DataAnnotations validation, OpenAPI document and Swagger UI.",
            "TasksController routes, CreateWorkTaskDto, UpdateWorkTaskDto",
            "/swagger"),
        new("Lab 14", "Logging and caching",
            "Service-level logs for CRUD plus IMemoryCache for task lists with invalidation after changes.",
            "WorkTaskService GetAll/Create/Update/Delete",
            "/api/tasks"),
        new("Practical 15", "Razor Pages",
            "Razor Pages connected to EF-backed service layer with binding and validation.",
            "Pages/Tasks/Create/Edit/Delete/Details/Index",
            "/Tasks/Create"),
        new("Practical 16", "Architecture, anti-patterns, logging, caching",
            "Controllers coordinate HTTP only; business logic sits in services, data access in repositories.",
            "TasksController, WorkTaskService, EfWorkTaskRepository",
            "/api/tasks"),
        new("Practical 17", "Authentication and authorization",
            "Demo header authentication, role-protected endpoints and claims/policy-protected endpoint.",
            "HeaderAuthenticationHandler, TasksController Authorize attributes, Program policies",
            "/api/tasks/secure/claims-demo")
    ];
}

public record WorkStage(string Name, string Topic, string Result, string CodeToShow, string DemoUrl);
