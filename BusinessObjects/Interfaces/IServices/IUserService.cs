using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Auth;
using BusinessObjects.Models.DTOs.Search;
using BusinessObjects.Models.DTOs.Token;
using BusinessObjects.Models.DTOs.User;

namespace BusinessObjects.Interfaces.IServices;

public interface IUserService
{
    Task<UserDTO> GetProfileByName(string userName);
    Task<UserDTO?> FindOrCreateUserAsync(ExternalAuthDTO externalAuth, List<string> roles);
    Task<TokenDTO> CreateAuthTokenAsync(string userName, int expDays = -1);
    Task<TokenDTO> RefeshAuthTokenAsync(string refeshToken);
    Task<string> GeneratePasswordResetTokenAsync(string email);
    Task CheckEmailExistedAsync(string email);
    Task ResetPasswordAsync(ChangePasswordDTO model);
    Task RemoveRefreshTokenAsync(string refreshToken);
    Task<string?> GetRefreshTokenAsync(string userName);
    Task<DateTimeOffset?> GetUnlockTime(string userName);
    Task<UserDTO> UnlockUser(string username);
    Task<UserBanDTO> IsLocked(string userName);
    Task<IEnumerable<UserDTO>> SearchUserByName(QuerySearchUserDTO query);
    Task<PaginatedData<UserDTO>> GetAll(QueryUserDTO query);
    Task EditUser(EditUserDTO editUserDTO);
    Task<UserDTO> BanUser(LockUserDTO lockUserDTO);
    Task<IEnumerable<UserDTO>> GetUserVoteTop(int type);
}
