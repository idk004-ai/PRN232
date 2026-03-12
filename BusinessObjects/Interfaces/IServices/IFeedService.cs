using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Feed;

namespace BusinessObjects.Interfaces.IServices;

public interface IFeedService
{
    Task CreateFeed(string username, CreateFeedDTO createFeedDTO);
    Task<FeedDTO> GetFeed(string username, string feedName);
    Task<PaginatedData<FeedDTO>> GetFeeds(string username, QueryFeedDTO query);
    Task AddTopicToFeed(string username, AddFeedDTO addFeedDTO);
    Task DeleteFeed(string username, string feedName);
    Task RemoveTopicFromFeed(string username, RemoveFeedDTO removeFeedDTO);
}