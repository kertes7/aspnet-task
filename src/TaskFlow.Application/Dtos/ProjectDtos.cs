using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Application.Dtos;

public record ProjectDto(
    int Id,
    string Name,
    string Code,
    string Description,
    DateTime CreatedAt,
    int OwnerId,
    string? OwnerName,
    int TasksCount);

public class CreateProjectDto
{
    [Required, StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(20, MinimumLength = 2)]
    public string Code { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int OwnerId { get; set; } = 1;
}

public class UpdateProjectDto : CreateProjectDto
{
}
