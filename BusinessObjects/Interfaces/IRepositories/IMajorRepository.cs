using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.Entities;

namespace BusinessObjects.Interfaces.IRepositories;

public interface IMajorRepository : IBaseRepository<Major>
{
    Task<Major?> GetMajorByName(string name);
    Task<IEnumerable<Major>> GetListMajorById(IEnumerable<Guid> ids);
    Task<PaginatedResponse<Major>> GetMajorsWithPaginationAsync(int pageNumber, int pageSize);
    Task<PaginatedResponse<Major>> GetMajorsByTopicIdAsync(Guid topicId, int pageNumber, int pageSize);
    Task<PaginatedResponse<Major>> GetMajorByTrash(int pageNumber, int pageSize);
    Task<IEnumerable<Major>> GetMajorByTrash();
}