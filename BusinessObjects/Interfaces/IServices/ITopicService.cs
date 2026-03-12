using BusinessObjects.Models.DTOs.Search;
using BusinessObjects.Models.DTOs.Topic;
using BusinessObjects.Models.DTOs;

namespace BusinessObjects.Interfaces.IServices;

public interface ITopicService
{
    Task<IEnumerable<TopicDTO>> SearchTopics(string value, int size);
    Task<TopicDTO> GetTopicById(Guid id);
    Task<IEnumerable<TopicDTO>> SearchTopicContainKeywordAsync(QuerySearchTopicDTO query);
    Task<IEnumerable<TopicDTO>> GetActiveTopics();
    Task<PaginatedResponse<TopicDTO>> GetTopicsWithPagination(int pageNumber, int pageSize);
    Task<PaginatedResponse<TopicDTO>> GetTopicsByMajorWithPagination(Guid majorId, int pageNumber, int pageSize);
    Task UpdateTopic(Guid id, EditTopicDTO editTopicDTO);
    Task<TopicDTO> MonitorTopic(string topicName);
    Task<TopicBanDTO> BanUser(CreateTopicBanDTO topicBan);
    Task UnbanUser(string username, string topic);
    Task<TopicBanDTO?> CheckBannedUser(string username, string topicName);
    Task CreateTopic(CreateTopicDTO topicDto);
    Task DeleteTopicToTrash(Guid id);
    Task RestoreTopic(Guid id);
    Task DeleteTopic(Guid id);
    Task<IEnumerable<TopicDTO>> GetTopicsByMajot(Guid idMajor);
    Task<PaginatedResponse<TopicTrashDTO>> GetTopicByTrashWithPaginationAsync(int pageNumber, int pageSize);
}