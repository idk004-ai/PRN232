using BusinessObjects.Constants;
using BusinessObjects.Models.DTOs.Attachment;

namespace BusinessObjects.Models.DTOs.Post;

public class PostDTO
{
    public Guid Id { get; set; }
    public string TopicAvatar { get; set; } = string.Empty;
    public string TopicName { get; set; } = string.Empty;
    public Guid? TopicId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string AuthorAvatar { get; set; } = string.Empty;
    public VoteType VoteType { get; set; } = VoteType.UNVOTE;
    public int UpVoteCount { get; set; }
    public int DownVoteCount { get; set; }
    public int VoteCount { get; set; }
    public long CommentCount { get; set; }
    public bool IsApproved { get; set; }
    public bool IsSaved { get; set; }
    public bool InTrash { get; set; }
    public IEnumerable<AttachmentDTO> AttachmentDTOs { get; set; } = [];
    public DateTime CreateAt { get; set; }
    public TimeSpan Elapsed { get; set; }
    public int? TotalDateDeleted { get; set; } = null;
}