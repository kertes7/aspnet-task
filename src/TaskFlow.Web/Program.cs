using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Mapping;
using TaskFlow.Application.Services;
using TaskFlow.Infrastructure;
using TaskFlow.Web.Auth;
using TaskFlow.Web.Filters;
using TaskFlow.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var dataProtectionKeysPath = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "DataProtectionKeys");
Directory.CreateDirectory(dataProtectionKeysPath);
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(dataProtectionKeysPath));

builder.Services.AddControllers(options => options.Filters.Add<ControllerLoggingFilter>());
builder.Services.AddRazorPages();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(_ => { }, typeof(WorkTaskProfile).Assembly);
builder.Services.AddTaskFlowInfrastructure(builder.Configuration);
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IWorkTaskService, WorkTaskService>();

builder.Services
    .AddAuthentication("DemoHeaders")
    .AddScheme<AuthenticationSchemeOptions, HeaderAuthenticationHandler>("DemoHeaders", _ => { });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ProjectDepartment", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("department", "ProjectOffice", "Student");
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskFlowDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.MapGet("/", () => Results.Redirect("/Tasks"));

app.Run();
