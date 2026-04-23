# Practical Work 13 - Exception Handling and Filters

## Purpose

The purpose of this practical work is to add centralized error handling and filters to the ASP.NET Core application.

## Implemented Result

The project contains custom exception middleware and an action filter. The exception middleware is responsible for converting exceptions into clear HTTP responses. The action filter logs controller action execution.

This separates cross-cutting logic from controllers. Controllers do not need to repeat try/catch blocks or logging code for every action.

## Main Files

- `src/TaskFlow.Web/Middleware/ExceptionHandlingMiddleware.cs` - catches exceptions globally.
- `src/TaskFlow.Web/Filters/ControllerLoggingFilter.cs` - logs controller action execution.
- `src/TaskFlow.Application/Common/AppException.cs` - custom application exception.
- `src/TaskFlow.Web/Controllers/TasksController.cs` - contains an endpoint for error demonstration.
- `src/TaskFlow.Web/Program.cs` - registers middleware and filter.

## Behavior

- normal requests return regular JSON or HTML responses;
- application errors are returned as `400 Bad Request`;
- unexpected errors are returned as `500 Internal Server Error`;
- controller actions are logged through the filter.

## How To Check

Run the project and open:

- `GET http://localhost:5124/api/tasks`
- `GET http://localhost:5124/api/tasks/error-demo`

Check the console logs for controller action messages and request timing.

## What This Work Proves

This work proves that exception handling and logging are implemented as reusable cross-cutting mechanisms instead of being duplicated in each controller method.

## Short Defense Text

In this practical work I added global exception handling middleware and a controller logging filter. These components process errors and logs in one place, which makes controllers cleaner and easier to maintain.
