namespace BusinessObjects.Models.DTOs.Search;
public class QueryCommentDTO : QueryParameters
{
    public string Filter { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public string Keyword { get; set; } = string.Empty;
    public Guid PostId { get; set; } 
    public Guid CommentId { get; set; }
    public Guid AttachmentId { get; set; } 
    public QueryCommentDTO()
    {
        OrderBy = "CreatedAt";
    }
}