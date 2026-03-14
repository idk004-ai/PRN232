namespace BusinessObjects.Models.DTOs.Notification;
public class NotificationDTO
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public string Receiver { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
