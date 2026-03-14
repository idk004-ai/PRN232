using BusinessObjects.Models.DTOs.Attachment;

namespace BusinessObjects.Models.DTOs.Post;

public class CreatePostDTO
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? TopicName { get; set; }
    public IEnumerable<AttachmentDTO> Attachments { get; set; } = [];
}