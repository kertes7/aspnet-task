# Laboratory Work 11 - Web API, DTO and Swagger

## Purpose

The purpose of this laboratory work is to improve the Web API by using DTO models and Swagger/OpenAPI documentation.

## Implemented Result

The API does not expose EF Core entities directly. It uses DTO classes for requests and responses. This makes the API contract clearer and protects the domain model from accidental external changes.

Swagger is enabled in the web project. It provides a browser-based page where all API endpoints can be viewed and tested. OpenAPI JSON is also available for generated API documentation.

## Main Files

- `src/TaskFlow.Application/Dtos/WorkTaskDtos.cs` - task DTO models.
- `src/TaskFlow.Application/Dtos/ProjectDtos.cs` - project DTO models.
- `src/TaskFlow.Application/Mapping/WorkTaskProfile.cs` - mapping configuration.
- `src/TaskFlow.Web/Controllers/TasksController.cs` - API controller using DTOs.
- `src/TaskFlow.Web/Controllers/ProjectsController.cs` - project API controller.
- `src/TaskFlow.Web/Program.cs` - Swagger and OpenAPI registration.

## DTO Usage

The project uses separate models for different API operations:

- list item DTOs for compact table/list responses;
- detail DTOs for full information;
- create request DTOs for new records;
- update request DTOs for edit operations.

This approach keeps request validation and response structure explicit.

## How To Check

Run the application and open:

- `http://localhost:5124/swagger`
- `http://localhost:5124/openapi/v1.json`

Test endpoints in Swagger:

- `GET /api/tasks`
- `POST /api/tasks`
- `GET /api/projects`
- `POST /api/projects`

## What This Work Proves

This work proves that the API has a documented contract. DTOs separate internal entities from external HTTP models, and Swagger provides a convenient interface for testing.

## Short Defense Text

In this laboratory work I added DTO-based API models and Swagger documentation. The controllers use request and response DTOs instead of directly exposing database entities, and the API can be tested through Swagger UI.
