using BusinessObjects.Models.DTOs.Post;
using BusinessObjects.Models.DTOs.Search;

namespace BusinessObjects.Interfaces.IServices;

public interface IPostService
{
   Task<PostDTO> CreatePost(CreatePostDTO postDTO, string username);
   Task<IEnumerable<PostDTO>> GetPostsAsync(QueryPostDTO query, string username);
   Task SavePostByUser(Guid postId, string username);
   Task RemoveSavePostByUser(Guid postId, string username);
   Task<IEnumerable<PostDTO>> GetPostSaveByUser(QueryPostDTO query, string username);
   Task RestorePostFromTrashAsync(Guid postId, string username);
   Task MovePostToTrash(Guid postId, string username);
   Task DeletePostForever(Guid postId);
   Task<PostDTO> GetPostById(Guid id, string username);
   Task<RecentPostDTO?> AddRecentPostByUser(RecentPostDTO recentPostDTO);
   Task EditPost(Guid id, EditPostDTO editPostDTO);
   Task<IEnumerable<PostDTO>> SearchPost(QuerySearchPostDTO query, string username);
   Task<PostDTO> ApprovePost(Guid id);
   Task<IEnumerable<PostDTO>> GetPostsInFeed(string username, string feedName, QueryPostDTO query);
   Task<IEnumerable<PostDTO>> GetRecentPostsByUser(string username);
   Task ClearRecentPostsByUser(string username);
   Task<IEnumerable<PostDTO>> GetPostsByTime(DateTime start, DateTime end);
   Task<string> GetAuthorOfPost(Guid id);
   Task DeletePost(Guid id);
   Task RestorePostFromTrash(Guid id, string username);
   Task<IEnumerable<PostDTO>> GetSuitPosts(string username, QueryPostDTO query);
   Task DeclinePost(Guid id);
   Task<IEnumerable<PostStatisticsDTO>> GetPostStatistics(string action, int date);
}