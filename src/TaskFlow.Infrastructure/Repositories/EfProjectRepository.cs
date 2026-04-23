using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain;

namespace TaskFlow.Infrastructure.Repositories;

public class EfProjectRepository : IProjectRepository
{
    private readonly TaskFlowDbContext _db;

    public EfProjectRepository(TaskFlowDbContext db)
    {
        _db = db;
    }

    public Task<List<Project>> GetAllAsync(string? search, CancellationToken cancellationToken)
    {
        var query = _db.Projects
            .Include(project => project.Owner)
            .Include(project => project.Tasks)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(project => project.Name.Contains(search) || project.Code.Contains(search));
        }

        return query.OrderBy(project => project.Name).ToListAsync(cancellationToken);
    }

    public Task<Project?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _db.Projects
            .Include(project => project.Owner)
            .Include(project => project.Tasks)
            .FirstOrDefaultAsync(project => project.Id == id, cancellationToken);
    }

    public async Task<Project> AddAsync(Project project, CancellationToken cancellationToken)
    {
        _db.Projects.Add(project);
        await _db.SaveChangesAsync(cancellationToken);
        return (await GetByIdAsync(project.Id, cancellationToken))!;
    }

    public async Task<bool> UpdateAsync(Project project, CancellationToken cancellationToken)
    {
        _db.Projects.Update(project);
        return await _db.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var project = await _db.Projects
            .Include(item => item.Tasks)
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
        if (project is null)
        {
            return false;
        }

        if (project.Tasks.Count > 0)
        {
            throw new TaskFlow.Application.Common.AppException("Project with tasks cannot be deleted.", 400);
        }

        _db.Projects.Remove(project);
        return await _db.SaveChangesAsync(cancellationToken) > 0;
    }

    public Task<bool> UserExistsAsync(int id, CancellationToken cancellationToken)
    {
        return _db.Users.AnyAsync(user => user.Id == id, cancellationToken);
    }

    public Task<bool> CodeExistsAsync(string code, int? excludedId, CancellationToken cancellationToken)
    {
        return _db.Projects.AnyAsync(project => project.Code == code && project.Id != excludedId, cancellationToken);
    }
}
