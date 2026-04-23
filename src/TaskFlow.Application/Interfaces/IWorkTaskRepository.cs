using TaskFlow.Domain;

namespace TaskFlow.Application.Interfaces;

public interface IWorkTaskRepository
{
    Task<List<WorkTask>> GetAllAsync(string? search, CancellationToken cancellationToken);
    Task<WorkTask?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<WorkTask> AddAsync(WorkTask task, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(WorkTask task, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<List<IGrouping<WorkItemStatus, WorkTask>>> GroupByStatusAsync(CancellationToken cancellationToken);
    Task<bool> ProjectExistsAsync(int id, CancellationToken cancellationToken);
    Task<bool> UserExistsAsync(int id, CancellationToken cancellationToken);
}
