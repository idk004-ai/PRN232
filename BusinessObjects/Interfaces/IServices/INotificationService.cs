using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Notification;
using BusinessObjects.Models.Entities;

namespace BusinessObjects.Interfaces.IServices;

public interface INotificationService
{
    Task Create(NotificationDTO notificationDTO);
    Task DeleteAllAsync(ApplicationUser user);
    Task Delete(Guid notificationId);
    Task MaskAsReadAll(string username);
    Task MaskAsRead(Guid notificationId);
    Task<PaginatedData<NotificationDTO>> GetAll(string username, QueryNotificationDTO query);
    Task<int> GetUnreadCount(string username);
    Task DeleteAll(string username);
}