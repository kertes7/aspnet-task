using TaskFlow.Application.Dtos;
using TaskFlow.Domain;

namespace TaskFlow.Application.Interfaces;

public interface IWorkTaskService
{
    Task<List<WorkTaskDto>> GetAllAsync(string? search, CancellationToken cancellationToken);
    Task<WorkTaskDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<WorkTaskDto> CreateAsync(CreateWorkTaskDto dto, string? actorEmail, CancellationToken cancellationToken);
    Task<WorkTaskDto?> UpdateAsync(int id, UpdateWorkTaskDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<Dictionary<WorkItemStatus, int>> GetStatusReportAsync(CancellationToken cancellationToken);
    Task<string> GetProtectedClaimDemoAsync(string userEmail, string department, CancellationToken cancellationToken);
}
