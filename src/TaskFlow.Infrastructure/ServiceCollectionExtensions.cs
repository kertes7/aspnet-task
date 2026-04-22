using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Interfaces;
using TaskFlow.Infrastructure.Repositories;

namespace TaskFlow.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTaskFlowInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var provider = configuration["DatabaseProvider"] ?? "Sqlite";
        var connectionString = configuration.GetConnectionString(provider == "SqlServer" ? "TaskFlowSqlServer" : "TaskFlowSqlite")
            ?? "Data Source=taskflow-migrations.db";

        services.AddDbContext<TaskFlowDbContext>(options =>
        {
            if (provider == "SqlServer")
            {
                options.UseSqlServer(connectionString);
            }
            else
            {
                options.UseSqlite(connectionString);
            }
        });
        services.AddScoped<IProjectRepository, EfProjectRepository>();
        services.AddScoped<IWorkTaskRepository, EfWorkTaskRepository>();
        return services;
    }
}
