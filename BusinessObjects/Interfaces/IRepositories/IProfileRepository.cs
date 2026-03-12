using BusinessObjects.Models.Entities;

namespace BusinessObjects.Interfaces.IRepositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> GetByName(string username);
}