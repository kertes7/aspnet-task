using TaskFlow.Domain;

namespace TaskFlow.Application.Interfaces;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync(string? search, CancellationToken cancellationToken);
    Task<Project?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Project> AddAsync(Project project, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Project project, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<bool> UserExistsAsync(int id, CancellationToken cancellationToken);
    Task<bool> CodeExistsAsync(string code, int? excludedId, CancellationToken cancellationToken);
}
