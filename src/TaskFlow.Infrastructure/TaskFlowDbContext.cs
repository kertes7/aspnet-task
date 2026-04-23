using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain;

namespace TaskFlow.Infrastructure;

public class TaskFlowDbContext : DbContext
{
    public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options) : base(options)
    {
    }

    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<WorkTask> Tasks => Set<WorkTask>();
    public DbSet<TaskComment> Comments => Set<TaskComment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().HasIndex(user => user.Email).IsUnique();
        modelBuilder.Entity<Project>().HasIndex(project => project.Code).IsUnique();
        modelBuilder.Entity<Project>()
            .HasOne(project => project.Owner)
            .WithMany(user => user.Projects)
            .HasForeignKey(project => project.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WorkTask>()
            .HasOne(task => task.Project)
            .WithMany(project => project.Tasks)
            .HasForeignKey(task => task.ProjectId);

        modelBuilder.Entity<WorkTask>()
            .HasOne(task => task.Assignee)
            .WithMany(user => user.AssignedTasks)
            .HasForeignKey(task => task.AssigneeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TaskComment>()
            .HasOne(comment => comment.WorkTask)
            .WithMany(task => task.Comments)
            .HasForeignKey(comment => comment.WorkTaskId);

        modelBuilder.Entity<AppUser>().HasData(
            new AppUser { Id = 1, FullName = "Ivan Hnetylo", Email = "ivan@example.com", Role = "Admin" },
            new AppUser { Id = 2, FullName = "Olena Manager", Email = "manager@example.com", Role = "Manager" },
            new AppUser { Id = 3, FullName = "Andrii Member", Email = "member@example.com", Role = "Member" });

        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Name = "Course Project", Code = "COURSE", Description = "ASP.NET Core cross-cutting student project", OwnerId = 1, CreatedAt = new DateTime(2026, 4, 22, 0, 0, 0, DateTimeKind.Utc) });

        modelBuilder.Entity<WorkTask>().HasData(
            new WorkTask { Id = 1, Title = "Build EF Core model", Description = "Create entities, DbContext and relations", ProjectId = 1, AssigneeId = 1, Status = WorkItemStatus.Done, DueDate = new DateTime(2026, 4, 24, 0, 0, 0, DateTimeKind.Utc) },
            new WorkTask { Id = 2, Title = "Expose Web API", Description = "Create CRUD endpoints with DTO validation", ProjectId = 1, AssigneeId = 2, Status = WorkItemStatus.InProgress, DueDate = new DateTime(2026, 4, 28, 0, 0, 0, DateTimeKind.Utc) });
    }
}
