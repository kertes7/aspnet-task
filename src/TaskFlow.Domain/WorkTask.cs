namespace TaskFlow.Domain;

public class WorkTask
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public WorkItemStatus Status { get; set; } = WorkItemStatus.Planned;
    public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(7);
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    public int AssigneeId { get; set; }
    public AppUser? Assignee { get; set; }
    public List<TaskComment> Comments { get; set; } = new();
}
