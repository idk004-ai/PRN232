using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessObjects.Interfaces.IServices
{
    public record NotificationMessage(IEnumerable<string> SendTo, string Message);

    public interface INotificationQueueService
    {
        ValueTask PushAsync(NotificationMessage notification);
    }
}
