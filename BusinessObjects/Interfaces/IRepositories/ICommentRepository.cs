using BusinessObjects.Models.DTOs.Comment;
using BusinessObjects.Models.DTOs.Search;
using BusinessObjects.Models.Entities;

namespace BusinessObjects.Interfaces.IRepositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<Comment?> GetCommentByIdAsync(Guid id);
    Task<IEnumerable<Comment>> GetCommentsByReplyIdAsync(Guid replyId);
    Task<List<Comment>> GetInitialCommentsAsync(QueryCommentDTO query);
    Task<List<Comment>> GetAllChildCommentsAsync(List<Comment> initialComments);
    Task<int> GetVoteCount(Guid id);
    Task<Comment> AddCommentAsync(CreateCommentDTO createCommentDTO);
    Task<IEnumerable<Comment>> GetCommentsByAttachmentIdAsync(QueryCommentDTO query);
    Task<IEnumerable<Comment?>> SearchCommentAsync(QueryCommentDTO query);
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId);
}