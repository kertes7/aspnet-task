# Laboratory Work 14 - Logging and Caching

## Purpose

The purpose of this laboratory work is to demonstrate logging and caching concepts in an ASP.NET Core application.

## Implemented Result

The project uses ASP.NET Core logging in middleware, filters and application services. Request timing middleware logs request execution time, and the controller filter logs action execution.

The application also registers in-memory caching. Task reports can be cached to avoid recalculating the same grouped result on every request.

## Main Files

- `src/TaskFlow.Web/Middleware/RequestTimingMiddleware.cs` - request timing and logging.
- `src/TaskFlow.Web/Filters/ControllerLoggingFilter.cs` - controller action logging.
- `src/TaskFlow.Application/Services/WorkTaskService.cs` - application-level logging and report logic.
- `src/TaskFlow.Web/Program.cs` - logging and memory cache registration.

## Logging Points

- request path and execution time;
- controller action start and finish;
- task creation/update/delete operations;
- application exceptions through exception middleware.

## How To Check

Run the project and open:

- `GET http://localhost:5124/api/tasks`
- `GET http://localhost:5124/api/tasks/report/status`
- `GET http://localhost:5124/Tasks`

Check the console output. It should contain request and controller logs.

## What This Work Proves

This work proves that cross-cutting observability is implemented in the project. Logs help understand what happens during request processing, and caching support is available for repeated application data.

## Short Defense Text

In this laboratory work I added logging to middleware, filters and services. The application also registers memory caching, which can be used for repeated report data.
