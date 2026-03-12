using BusinessObjects.Models.DTOs.Search;
using BusinessObjects.Models.Entities;
using BusinessObjects.Models.DTOs;

namespace BusinessObjects.Interfaces.IRepositories;

public interface ITopicRepository : IBaseRepository<Topic>
{
    Task<Topic?> GetTopicByName(string name);
    Task<IEnumerable<Topic>> SearchTopics(string value, int size);
    Task<IEnumerable<Topic>> SearchTopicContainKeywordAsync(QuerySearchTopicDTO query);
    Task<IEnumerable<Topic>> GetTopics();
    Task<PaginatedResponse<Topic>> GetTopicsWithPaginationAsync(int pageNumber, int pageSize);
    Task<PaginatedResponse<Topic>> GetTopicsByMajorWithPaginationAsync(Guid majorId, int pageNumber, int pageSize);
    Task<IEnumerable<Topic>> GetModeratedTopics(string username);
    Task<TopicBan?> GetTopicBan(string username, string topic);
    Task UpdateTopicBan(TopicBan topicBan);
    Task<TopicBan> BanUser(TopicBan topicBan);
    Task<TopicBan> UnbanUser(TopicBan lockUser);
    Task<IEnumerable<Topic>> GetModeratedTopics(IEnumerable<string> moderatetopics);
    Task<Topic?> GetTopicById(Guid id);
    Task<IEnumerable<Topic>> GetTopicsByMajor(Guid idMajor);
    Task<bool> ExistsByNameAsync(string name);
    Task<PaginatedResponse<Topic>> GetTopicByTrashWithPaginationAsync(int pageNumber, int pageSize);
    Task<IEnumerable<Topic>> GetTopicsByTrash();
    Task<Topic?> GetTopicPostById(Guid id);
}