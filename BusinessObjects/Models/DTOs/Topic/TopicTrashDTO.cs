namespace BusinessObjects.Models.DTOs.Topic;

public class TopicTrashDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int TotalDateDeleted { get; set; }
}