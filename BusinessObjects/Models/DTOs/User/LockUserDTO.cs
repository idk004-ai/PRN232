namespace BusinessObjects.Models.DTOs.User;

public class LockUserDTO
{
    public string UserName { get; set; } = string.Empty;
    public int LockoutDays { get; set; }
    public string Action { get; set; } = string.Empty;
}