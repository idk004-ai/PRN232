using BusinessObjects.Models.DTOs.Major;

namespace BusinessObjects.Models.DTOs.Topic;

public class TopicDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public string Banner { get; set; } = string.Empty;
    public long PostCount { get; set; }
    public bool NeedReview { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public DateTime? Banned { get; set; }
    public IEnumerable<MajorDTO> MajorDTOs { get; set; } = new List<MajorDTO>();
}