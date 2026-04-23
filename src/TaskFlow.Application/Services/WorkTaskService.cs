using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TaskFlow.Application.Common;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain;

namespace TaskFlow.Application.Services;

public class WorkTaskService : IWorkTaskService
{
    private const string CacheKey = "work-tasks:list";
    private readonly IWorkTaskRepository _repository;
    private readonly IMemoryCache _cache;
    private readonly ILogger<WorkTaskService> _logger;
    private readonly IMapper _mapper;

    public WorkTaskService(IWorkTaskRepository repository, IMemoryCache cache, ILogger<WorkTaskService> logger, IMapper mapper)
    {
        _repository = repository;
        _cache = cache;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<WorkTaskDto>> GetAllAsync(string? search, CancellationToken cancellationToken)
    {
        var cacheKey = string.IsNullOrWhiteSpace(search) ? CacheKey : $"{CacheKey}:{search}";
        if (_cache.TryGetValue(cacheKey, out List<WorkTaskDto>? cached))
        {
            _logger.LogInformation("Cache hit for task list. Search={Search}, Count={Count}", search, cached!.Count);
            return cached;
        }

        var started = DateTime.UtcNow;
        var tasks = await _repository.GetAllAsync(search, cancellationToken);
        var result = _mapper.Map<List<WorkTaskDto>>(tasks);
        _cache.Set(cacheKey, result, TimeSpan.FromSeconds(30));
        _logger.LogInformation("Cache miss for task list. Search={Search}, Count={Count}, ElapsedMs={ElapsedMs}",
            search, result.Count, (DateTime.UtcNow - started).TotalMilliseconds);
        return result;
    }

    public async Task<WorkTaskDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var task = await _repository.GetByIdAsync(id, cancellationToken);
        _logger.LogInformation("Read task Id={TaskId}, Found={Found}", id, task is not null);
        return task is null ? null : _mapper.Map<WorkTaskDto>(task);
    }

    public async Task<WorkTaskDto> CreateAsync(CreateWorkTaskDto dto, string? actorEmail, CancellationToken cancellationToken)
    {
        await ValidateRelationsAsync(dto.ProjectId, dto.AssigneeId, cancellationToken);
        if (dto.Status == WorkItemStatus.Done && dto.DueDate > DateTime.UtcNow.AddDays(1))
        {
            throw new AppException("A task cannot be created as Done when its due date is still in the future.");
        }

        var task = new WorkTask
        {
            Title = dto.Title.Trim(),
            Description = dto.Description.Trim(),
            Status = dto.Status,
            DueDate = dto.DueDate,
            ProjectId = dto.ProjectId,
            AssigneeId = dto.AssigneeId
        };

        var saved = await _repository.AddAsync(task, cancellationToken);
        InvalidateCache();
        _logger.LogInformation("Created task Id={TaskId}, Actor={Actor}", saved.Id, actorEmail ?? "anonymous");
        return _mapper.Map<WorkTaskDto>(saved);
    }

    public async Task<WorkTaskDto?> UpdateAsync(int id, UpdateWorkTaskDto dto, CancellationToken cancellationToken)
    {
        await ValidateRelationsAsync(dto.ProjectId, dto.AssigneeId, cancellationToken);
        var task = await _repository.GetByIdAsync(id, cancellationToken);
        if (task is null)
        {
            return null;
        }

        task.Title = dto.Title.Trim();
        task.Description = dto.Description.Trim();
        task.Status = dto.Status;
        task.DueDate = dto.DueDate;
        task.ProjectId = dto.ProjectId;
        task.AssigneeId = dto.AssigneeId;

        await _repository.UpdateAsync(task, cancellationToken);
        InvalidateCache();
        _logger.LogInformation("Updated task Id={TaskId}, Status={Status}", id, task.Status);
        return _mapper.Map<WorkTaskDto>(task);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var deleted = await _repository.DeleteAsync(id, cancellationToken);
        if (deleted)
        {
            InvalidateCache();
            _logger.LogWarning("Deleted task Id={TaskId}", id);
        }
        return deleted;
    }

    public async Task<Dictionary<WorkItemStatus, int>> GetStatusReportAsync(CancellationToken cancellationToken)
    {
        var groups = await _repository.GroupByStatusAsync(cancellationToken);
        return groups.ToDictionary(group => group.Key, group => group.Count());
    }

    public Task<string> GetProtectedClaimDemoAsync(string userEmail, string department, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Claims demo requested by {Email} from {Department}", userEmail, department);
        return Task.FromResult($"Access granted for {userEmail} from department {department}.");
    }

    private async Task ValidateRelationsAsync(int projectId, int assigneeId, CancellationToken cancellationToken)
    {
        if (!await _repository.ProjectExistsAsync(projectId, cancellationToken))
        {
            throw new AppException($"Project with id {projectId} was not found.", 404);
        }

        if (!await _repository.UserExistsAsync(assigneeId, cancellationToken))
        {
            throw new AppException($"User with id {assigneeId} was not found.", 404);
        }
    }

    private void InvalidateCache()
    {
        _cache.Remove(CacheKey);
    }
}
