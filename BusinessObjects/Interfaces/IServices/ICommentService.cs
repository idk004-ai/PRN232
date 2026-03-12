using BusinessObjects.Models.DTOs.Comment;
using BusinessObjects.Models.DTOs.Search;

namespace BusinessObjects.Interfaces.IServices;

public interface ICommentService
{
   Task<IEnumerable<CommentDTO>> GetCommentsByPostIdAsync(QueryCommentDTO query, string username);
   Task<CommentDTO> AddCommentAsync(CreateCommentDTO createCommentDTO, string username);
   Task<CommentDTO> GetCommentByIdAsync(Guid id, string username);
   Task<IEnumerable<CommentDTO>> GetCommentsByAttachmentIdAsync(QueryCommentDTO query, string username);
   Task UpdateComment(CommentUpdateDTO commentDTO, Guid id);
   Task DeleteComment(Guid id);
   Task<IEnumerable<CommentDTO>> SearchCommentAsync(QueryCommentDTO query, string username);
   Task<IEnumerable<string>> GetCommentersByPostIdAsync(Guid postId);
   Task SendCommentNotificationsAsync(CommentDTO comment, string username);
}