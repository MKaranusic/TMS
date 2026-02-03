namespace TMS.Data.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public required string Subject { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }

    public int StatusId { get; set; }
    public required StatusEntity Status { get; set; }
}
