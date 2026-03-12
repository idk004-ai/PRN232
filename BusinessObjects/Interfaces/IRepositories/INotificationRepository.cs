using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Notification;
using BusinessObjects.Models.Entities;
namespace BusinessObjects.Interfaces.IRepositories;
public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<PaginatedData<Notification>> GetAllAsync(string username, QueryNotificationDTO query);
    Task<Notification> GetByIdAsync(Guid notificationId);
    Task<int> GetUnreadCount(ApplicationUser user);
    Task<IEnumerable<Notification>> ReadAllAsync(ApplicationUser user);
    Task UpdateRangeNotification(IEnumerable<Notification> notifications);
    Task<IEnumerable<Notification>> GetReceiverNotifications(ApplicationUser user);
}