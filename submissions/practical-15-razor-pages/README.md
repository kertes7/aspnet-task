# Practical Work 15 - Razor Pages

## Purpose

The purpose of this practical work is to build server-rendered pages with Razor Pages and connect them to the application service layer.

## Implemented Result

The project contains a complete Razor Pages CRUD interface for tasks. Each page has a `.cshtml` view and a matching PageModel class. PageModels call `IWorkTaskService` and `IProjectService` instead of working directly with EF Core.

This keeps UI logic separated from data access logic and follows the same layered approach as the API.

## Main Files

- `src/TaskFlow.Web/Pages/Tasks/Index.cshtml`
- `src/TaskFlow.Web/Pages/Tasks/Index.cshtml.cs`
- `src/TaskFlow.Web/Pages/Tasks/Create.cshtml`
- `src/TaskFlow.Web/Pages/Tasks/Create.cshtml.cs`
- `src/TaskFlow.Web/Pages/Tasks/Edit.cshtml`
- `src/TaskFlow.Web/Pages/Tasks/Edit.cshtml.cs`
- `src/TaskFlow.Web/Pages/Tasks/Delete.cshtml`
- `src/TaskFlow.Web/Pages/Tasks/Delete.cshtml.cs`

## Page Flow

- `Index` displays all tasks.
- `Create` shows a form and saves a new task.
- `Details` displays one task.
- `Edit` loads existing data and saves changes.
- `Delete` asks for confirmation before deletion.

## How To Check

Open the following pages:

- `http://localhost:5124/Tasks`
- `http://localhost:5124/Tasks/Create`
- `http://localhost:5124/Tasks/Edit/1`
- `http://localhost:5124/Tasks/Delete/1`

## What This Work Proves

This work proves that the project can be used as a normal web application, not only through API calls. Razor Pages provide forms and navigation for browser users.

## Short Defense Text

In this practical work I implemented Razor Pages for task CRUD operations. The PageModel classes use application services, which keeps UI logic separated from database access.
