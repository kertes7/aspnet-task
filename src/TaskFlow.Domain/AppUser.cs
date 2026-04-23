namespace TaskFlow.Domain;

public class AppUser
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "Member";
    public List<Project> Projects { get; set; } = new();
    public List<WorkTask> AssignedTasks { get; set; } = new();
}
