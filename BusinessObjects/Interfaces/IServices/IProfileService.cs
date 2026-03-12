using BusinessObjects.Models.DTOs.Profile;

namespace BusinessObjects.Interfaces.IServices;

public interface IProfileService
{
    Task<ProfileDTO?> GetByName(string username);
    Task UpdateProfile(string username, ProfileDTO profileDTO);
    Task InsertProfile(ProfileDTO profileDTO, string username);
}