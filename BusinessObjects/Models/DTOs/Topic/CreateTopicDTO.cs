namespace BusinessObjects.Models.DTOs.Topic;

public class CreateTopicDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public string Banner { get; set; } = string.Empty;
    public List<Guid> MajorDTOs { get; set; } = new List<Guid>();
}