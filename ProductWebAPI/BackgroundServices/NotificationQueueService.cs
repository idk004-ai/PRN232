using System.Threading.Channels;
using Microsoft.AspNetCore.SignalR;
using ProductWebAPI.Hubs;
using BusinessObjects.Interfaces.IServices;

namespace ProductWebAPI.BackgroundServices;

public record Notification(IEnumerable<string> SendTo, string Message);

public class NotificationQueueService(
    IHubContext<NotificationHub, INotificationClient> hubContext,
    ConnectionManager connectionManager) : BackgroundService, INotificationQueueService
{
    private readonly Channel<Notification> _channel = Channel.CreateUnbounded<Notification>();
    private readonly IHubContext<NotificationHub, INotificationClient> _hubContext = hubContext;
    private readonly ConnectionManager _connectionManager = connectionManager;

    public ValueTask PushAsync(NotificationMessage notification)
        => _channel.Writer.WriteAsync(new Notification(notification.SendTo, notification.Message));

    public ValueTask PushAsync(Notification notification)
        => _channel.Writer.WriteAsync(notification);
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var notification = await _channel.Reader.ReadAsync(stoppingToken);
            await HandleNotificationsAsync(notification);
        }
    }

    private async Task HandleNotificationsAsync(Notification notification)
    {
        var connectionIds = notification.SendTo.SelectMany(_connectionManager.GetConnections).Distinct();
        if (connectionIds == null || !connectionIds.Any()) return;
        await _hubContext.Clients.Clients(connectionIds)
                .ReceiveNotification(notification.Message);
    }
}