# Practical Work 17 - Authentication, Roles and Claims

## Purpose

The purpose of this practical work is to add authentication and authorization concepts to the ASP.NET Core project. The work demonstrates roles, claims and policy-based access control.

## Implemented Result

The project contains a demo authentication handler that reads user data from HTTP headers. This makes it possible to test authorization without creating a full login page.

Role-based authorization is used for protected API actions. Policy-based authorization is configured through a custom claim requirement. The application also demonstrates how claims can be read from `HttpContext.User`.

## Main Files

- `src/TaskFlow.Web/Auth/HeaderAuthenticationHandler.cs` - demo authentication handler.
- `src/TaskFlow.Web/Controllers/TasksController.cs` - protected endpoints and claims demo.
- `src/TaskFlow.Web/Program.cs` - authentication, authorization and policy registration.

## Authorization Features

- demo user identity from HTTP headers;
- role claim from `X-Demo-Role`;
- department claim from `X-Demo-Department`;
- role-protected endpoints;
- policy-protected endpoint;
- correct middleware order: `UseAuthentication()` before `UseAuthorization()`.

## How To Check

Open Swagger:

- `http://localhost:5124/swagger`

Call:

- `GET /api/tasks/secure/claims-demo`

Use headers:

```http
X-Demo-User: ivan@example.com
X-Demo-Role: Admin
X-Demo-Department: ProjectOffice
```

Without these headers, protected endpoints should return an authorization error.

## What This Work Proves

This work proves that the application can identify a user, read roles and claims, and restrict access to selected endpoints.

## Short Defense Text

In this practical work I added demo authentication and authorization. The project supports role-based and policy-based protection, reads claims from the current user and uses the correct authentication middleware order.
