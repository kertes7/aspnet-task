using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain;

namespace TaskFlow.Infrastructure.Repositories;

public class EfWorkTaskRepository : IWorkTaskRepository
{
    private readonly TaskFlowDbContext _db;

    public EfWorkTaskRepository(TaskFlowDbContext db)
    {
        _db = db;
    }

    public Task<List<WorkTask>> GetAllAsync(string? search, CancellationToken cancellationToken)
    {
        var query = _db.Tasks
            .Include(task => task.Project)
            .Include(task => task.Assignee)
            .Include(task => task.Comments)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(task => task.Title.Contains(search) || task.Description.Contains(search));
        }

        return query.OrderBy(task => task.DueDate).ToListAsync(cancellationToken);
    }

    public Task<WorkTask?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _db.Tasks
            .Include(task => task.Project)
            .Include(task => task.Assignee)
            .Include(task => task.Comments)
            .FirstOrDefaultAsync(task => task.Id == id, cancellationToken);
    }

    public async Task<WorkTask> AddAsync(WorkTask task, CancellationToken cancellationToken)
    {
        _db.Tasks.Add(task);
        await _db.SaveChangesAsync(cancellationToken);
        return (await GetByIdAsync(task.Id, cancellationToken))!;
    }

    public async Task<bool> UpdateAsync(WorkTask task, CancellationToken cancellationToken)
    {
        _db.Tasks.Update(task);
        return await _db.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var task = await _db.Tasks.FindAsync([id], cancellationToken);
        if (task is null)
        {
            return false;
        }

        _db.Tasks.Remove(task);
        return await _db.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<List<IGrouping<WorkItemStatus, WorkTask>>> GroupByStatusAsync(CancellationToken cancellationToken)
    {
        var tasks = await _db.Tasks.AsNoTracking().ToListAsync(cancellationToken);
        return tasks.GroupBy(task => task.Status).ToList();
    }

    public Task<bool> ProjectExistsAsync(int id, CancellationToken cancellationToken)
    {
        return _db.Projects.AnyAsync(project => project.Id == id, cancellationToken);
    }

    public Task<bool> UserExistsAsync(int id, CancellationToken cancellationToken)
    {
        return _db.Users.AnyAsync(user => user.Id == id, cancellationToken);
    }
}
