using BusinessObjects.Constants;

namespace BusinessObjects.Models.DTOs.Vote;

public class VoteCommentDTO
{
    public Guid CommentId { get; set; }
    public VoteType Type { get; set; }
}