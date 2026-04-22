namespace TaskFlow.Domain;

public class TaskComment
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int WorkTaskId { get; set; }
    public WorkTask? WorkTask { get; set; }
    public int AuthorId { get; set; }
    public AppUser? Author { get; set; }
}
