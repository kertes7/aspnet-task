# Practical Work 14 - Swagger, Validation and Routing

## Purpose

The purpose of this practical work is to improve API usability by adding Swagger documentation, validation and clear routing.

## Implemented Result

The Web API uses route attributes for controllers and actions. Endpoints are grouped under `/api/tasks` and `/api/projects`. Swagger is enabled, so all routes can be viewed and tested from the browser.

DTO classes contain validation attributes. ASP.NET Core model validation checks request bodies before service logic is executed. Invalid requests return `400 Bad Request`.

## Main Files

- `src/TaskFlow.Web/Controllers/TasksController.cs` - task routes and validation responses.
- `src/TaskFlow.Web/Controllers/ProjectsController.cs` - project routes.
- `src/TaskFlow.Application/Dtos/WorkTaskDtos.cs` - task validation rules.
- `src/TaskFlow.Application/Dtos/ProjectDtos.cs` - project validation rules.
- `src/TaskFlow.Web/Program.cs` - Swagger and routing configuration.

## API Routes

- `GET /api/tasks`
- `GET /api/tasks/{id:int}`
- `POST /api/tasks`
- `PUT /api/tasks/{id:int}`
- `DELETE /api/tasks/{id:int}`
- `GET /api/projects`
- `POST /api/projects`

## How To Check

Open Swagger:

- `http://localhost:5124/swagger`

Try sending an invalid request body to:

- `POST /api/tasks`
- `POST /api/projects`

Swagger should show all endpoints and validation should return an error response for invalid input.

## What This Work Proves

This work proves that the API is documented, testable and protected from invalid input through model validation.

## Short Defense Text

In this practical work I configured Swagger, attribute routing and DTO validation. The API routes are clear, the endpoints are documented, and invalid request data is rejected before it reaches business logic.
