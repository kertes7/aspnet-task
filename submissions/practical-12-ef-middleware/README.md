# Practical Work 12 - Entity Framework and Middleware

## Purpose

The purpose of this practical work is to combine database functionality with ASP.NET Core middleware. The project must show that request processing is controlled by a middleware pipeline and that database logic works inside that pipeline.

## Implemented Result

The project contains custom middleware for exception handling and request timing. The exception middleware catches application errors and returns a consistent JSON error response. The timing middleware measures request duration and writes it to the response headers.

Entity Framework Core remains integrated with the request pipeline through scoped services. Controllers call application services, services call repositories, and repositories use `TaskFlowDbContext`.

## Main Files

- `src/TaskFlow.Web/Middleware/ExceptionHandlingMiddleware.cs` - global exception handling.
- `src/TaskFlow.Web/Middleware/RequestTimingMiddleware.cs` - request timing header.
- `src/TaskFlow.Web/Program.cs` - middleware registration order.
- `src/TaskFlow.Application/Common/AppException.cs` - application-level exception.
- `src/TaskFlow.Infrastructure/TaskFlowDbContext.cs` - database context.

## Middleware Behavior

- exceptions are converted to JSON responses;
- known application errors return clear messages;
- request execution time is added as `X-Elapsed-Milliseconds`;
- database requests go through the same middleware pipeline as other endpoints.

## How To Check

Run the project and call:

- `GET http://localhost:5124/api/tasks`
- `GET http://localhost:5124/api/tasks/error-demo`

In the response headers, check:

- `X-Elapsed-Milliseconds`

## What This Work Proves

This work proves that the application uses the ASP.NET Core middleware pipeline and that cross-cutting behavior can be added without duplicating logic inside controllers.

## Short Defense Text

In this practical work I added custom middleware for request timing and exception handling. EF Core operations are executed through the standard request pipeline, and application errors are returned as structured JSON responses.
