# Laboratory Work 13 - Web Application UI

## Purpose

The purpose of this laboratory work is to create a user interface for the ASP.NET Core application. The UI must allow users to interact with the same data that is available through the Web API.

## Implemented Result

The TaskFlow project contains Razor Pages for task management. The UI works with the application service layer, so it uses real database data and the same business logic as the API.

The user can view a task list, open details, create a new task, edit an existing task and delete a task through a confirmation page.

## Main Files

- `src/TaskFlow.Web/Pages/Tasks/Index.cshtml` - task list.
- `src/TaskFlow.Web/Pages/Tasks/Details.cshtml` - task details.
- `src/TaskFlow.Web/Pages/Tasks/Create.cshtml` - create form.
- `src/TaskFlow.Web/Pages/Tasks/Edit.cshtml` - edit form.
- `src/TaskFlow.Web/Pages/Tasks/Delete.cshtml` - delete confirmation.
- `src/TaskFlow.Web/Pages/Shared/_Layout.cshtml` - shared page layout.
- `src/TaskFlow.Web/wwwroot/css/site.css` - UI styles.

## UI Features

- task table with project, assignee, status and due date;
- forms with server-side validation;
- select lists for status, project and assignee;
- detail page for a single task;
- delete confirmation before removing data;
- navigation links between pages.

## How To Check

Run the application and open:

- `http://localhost:5124/Tasks`
- `http://localhost:5124/Tasks/Create`
- `http://localhost:5124/Tasks/Details/1`
- `http://localhost:5124/Tasks/Edit/1`
- `http://localhost:5124/Tasks/Delete/1`

## What This Work Proves

This work proves that the project is not only an API. It also has a server-rendered web interface that allows the user to work with task data from the browser.

## Short Defense Text

In this laboratory work I created a Razor Pages UI for the TaskFlow system. The interface supports list, details, create, edit and delete operations and uses the same application services as the Web API.
