using TaskFlow.Application.Dtos;

namespace TaskFlow.Application.Interfaces;

public interface IProjectService
{
    Task<List<ProjectDto>> GetAllAsync(string? search, CancellationToken cancellationToken);
    Task<ProjectDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<ProjectDto> CreateAsync(CreateProjectDto dto, CancellationToken cancellationToken);
    Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
