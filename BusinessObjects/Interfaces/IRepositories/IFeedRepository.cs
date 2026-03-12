using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Feed;
using BusinessObjects.Models.Entities;

namespace BusinessObjects.Interfaces.IRepositories;

public interface IFeedRepository : IBaseRepository<Feed>
{
    Task<Feed?> GetFeed(string username, string feedName);
    Task<PaginatedData<Feed>> GetFeeds(string username, QueryFeedDTO query);
}