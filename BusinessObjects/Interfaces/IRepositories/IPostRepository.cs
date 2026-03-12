using BusinessObjects.Models.DTOs.Post;
using BusinessObjects.Models.DTOs.Search;
using BusinessObjects.Models.Entities;

namespace BusinessObjects.Interfaces.IRepositories;

public interface IPostRepository : IBaseRepository<Post>
{
    Task<IEnumerable<Post>> GetPostsAsync(QueryPostDTO query);
    Task SavePostByUser(Post post, ApplicationUser user);
    Task RemoveFromSavedByUser(SavedPost postByUser);
    Task<SavedPost?> GetSavedPostByUser(Guid postID, string username);
    Task<IEnumerable<Post>> GetSavedPostsByUser(QueryPostDTO query);
    Task<Post?> GetPostByIdAsync(Guid id, bool isAll = false);
    Task AddOrUpdateRecentPost(RecentPost recentPost);
    Task<IEnumerable<Post>> SearchPost(QuerySearchPostDTO query);
    Task<IEnumerable<Post>> GetPostsInTopics(QueryPostDTO query, ICollection<Topic> topics);
    Task<IEnumerable<Post>> GetRecentPosts(string username);
    Task ClearRecentPosts(string username);
    Task<IEnumerable<Post>> GetPostsByTimeAsync(DateTime startDate, DateTime endDate);
    Task<bool> ExistsAsync(Guid postId);
    Task<IEnumerable<Post>> GetSuitPosts(QueryPostDTO query, string majorName);
    Task<IEnumerable<Post>> GetStatisticsPost(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Post>> GetPostsByTrash();
}