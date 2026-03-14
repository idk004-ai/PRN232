namespace BusinessObjects.Models.DTOs.Comment;

public class CreateCommentDTO
{
    public string Content { get; set; } = string.Empty;
    public string? Author { get; set; } = string.Empty;
    public Guid? PostId { get; set; }
    public Guid? AttachmentId { get; set; }
    public Guid? ReplyId { get; set; }

}