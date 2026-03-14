using BusinessObjects.Models.DTOs.Attachment;

namespace BusinessObjects.Models.DTOs.Post;

public class EditPostDTO
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public IEnumerable<AttachmentDTO> Attachments { get; set; } = [];
}