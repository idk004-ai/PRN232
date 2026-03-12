using BusinessObjects.Models.DTOs.Search;
using BusinessObjects.Models.DTOs.User;
using BusinessObjects.Models.Entities;

namespace BusinessObjects.Interfaces.IRepositories;

public interface IUserRepository : IBaseRepository<ApplicationUser>
{
    Task<ApplicationUser?> FindUserByRefreshTokenAsync(string refreshToken);
    Task<IEnumerable<ApplicationUser>> SearchUserByName(QuerySearchUserDTO query);
    Task<IEnumerable<ApplicationUser>> GetUsers(QueryUserDTO query);
    Task<ApplicationUser> GetByName(string userName);
    Task<bool> ExistsByUsernameAsync(string username);
    Task<bool> ExistsByEmailAsync(string email);
    Task<string?> GetUserRoleIdAsync();
    Task<IEnumerable<ApplicationUser>> GetUserVoteTop(string userRoleId);
    Task<IEnumerable<ApplicationUser>> GetUserCommentTop(string userRoleId);
    Task<IEnumerable<ApplicationUser>> GetUserCreatePostTop(string userRoleId);
}