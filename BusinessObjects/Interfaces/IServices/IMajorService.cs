using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Major;

namespace BusinessObjects.Interfaces.IServices;

public interface IMajorService
{
    Task<PaginatedResponse<MajorDTO>> GetMajorPaginated(int pageNumber, int pageSize);
    Task<PaginatedResponse<MajorDTO>> GetMajorsByTopicId(Guid topicId, int pageNumber, int pageSize);
    Task<IEnumerable<MajorDTO>> GetAllMajor();
    Task CreateMajor(CreateMajorDTO createMajorDTO);
    Task UpdateMajor(UpdateMajorDTO updateMajorDTO, Guid id);
    Task DeleteMajorToTrash(Guid id);
    Task<PaginatedResponse<MajorTrashDTO>> GetMajorByTrash(int pageNumber, int pageSize);
    Task RestoreMajor(Guid id);
    Task DeleteMajor(Guid id);
}
