using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskFlow.Application.Common;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain;

namespace TaskFlow.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;
    private readonly ILogger<ProjectService> _logger;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository repository, ILogger<ProjectService> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<ProjectDto>> GetAllAsync(string? search, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAllAsync(search, cancellationToken);
        _logger.LogInformation("Read project list. Search={Search}, Count={Count}", search, projects.Count);
        return _mapper.Map<List<ProjectDto>>(projects);
    }

    public async Task<ProjectDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(id, cancellationToken);
        _logger.LogInformation("Read project Id={ProjectId}, Found={Found}", id, project is not null);
        return project is null ? null : _mapper.Map<ProjectDto>(project);
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectDto dto, CancellationToken cancellationToken)
    {
        await ValidateAsync(dto.OwnerId, dto.Code, null, cancellationToken);
        var project = new Project
        {
            Name = dto.Name.Trim(),
            Code = dto.Code.Trim().ToUpperInvariant(),
            Description = dto.Description.Trim(),
            OwnerId = dto.OwnerId,
            CreatedAt = DateTime.UtcNow
        };

        var saved = await _repository.AddAsync(project, cancellationToken);
        _logger.LogInformation("Created project Id={ProjectId}, Code={Code}", saved.Id, saved.Code);
        return _mapper.Map<ProjectDto>(saved);
    }

    public async Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto dto, CancellationToken cancellationToken)
    {
        await ValidateAsync(dto.OwnerId, dto.Code, id, cancellationToken);
        var project = await _repository.GetByIdAsync(id, cancellationToken);
        if (project is null)
        {
            return null;
        }

        project.Name = dto.Name.Trim();
        project.Code = dto.Code.Trim().ToUpperInvariant();
        project.Description = dto.Description.Trim();
        project.OwnerId = dto.OwnerId;

        await _repository.UpdateAsync(project, cancellationToken);
        _logger.LogInformation("Updated project Id={ProjectId}, Code={Code}", project.Id, project.Code);
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var deleted = await _repository.DeleteAsync(id, cancellationToken);
        if (deleted)
        {
            _logger.LogWarning("Deleted project Id={ProjectId}", id);
        }
        return deleted;
    }

    private async Task ValidateAsync(int ownerId, string code, int? excludedId, CancellationToken cancellationToken)
    {
        if (!await _repository.UserExistsAsync(ownerId, cancellationToken))
        {
            throw new AppException($"User with id {ownerId} was not found.", 404);
        }

        if (await _repository.CodeExistsAsync(code.Trim().ToUpperInvariant(), excludedId, cancellationToken))
        {
            throw new AppException($"Project code '{code}' is already used.", 400);
        }
    }
}
