namespace TMS.Data.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public required string Subject { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
