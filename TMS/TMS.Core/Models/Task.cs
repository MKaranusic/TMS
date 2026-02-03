namespace TMS.Core.Models;

public class Task
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}
