namespace BusinessObjects.Models.DTOs.User
{
    public class UserBanDTO
    {
        public bool IsLocked { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}