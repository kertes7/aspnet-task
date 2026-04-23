using System.ComponentModel.DataAnnotations;
using TaskFlow.Domain;

namespace TaskFlow.Application.Dtos;

public record WorkTaskDto(
    int Id,
    string Title,
    string Description,
    WorkItemStatus Status,
    DateTime DueDate,
    int ProjectId,
    string? ProjectName,
    int AssigneeId,
    string? AssigneeName,
    int CommentsCount);

public class CreateWorkTaskDto
{
    [Required, StringLength(120, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Range(0, 3)]
    public WorkItemStatus Status { get; set; } = WorkItemStatus.Planned;

    public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(7);

    [Range(1, int.MaxValue)]
    public int ProjectId { get; set; }

    [Range(1, int.MaxValue)]
    public int AssigneeId { get; set; }
}

public class UpdateWorkTaskDto : CreateWorkTaskDto
{
}
