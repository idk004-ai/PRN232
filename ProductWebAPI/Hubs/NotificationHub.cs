using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ProductWebAPI.Hubs;

public interface INotificationClient
{
    Task ReceiveNotification(string message);
    Task UserConnected(string userName);
    Task UserDisconnected(string userName);
    Task OnlineUsersCount(int count);
}
[Authorize]
public class NotificationHub(ConnectionManager connectionManager) : Hub<INotificationClient>
{
    private readonly ConnectionManager _connectionManager = connectionManager;
    public override async Task OnConnectedAsync()
    {
        var userName = Context.User?.Identity?.Name
            ?? throw new Exception("User is not authenticated");

        var connectionId = Context.ConnectionId;
        _connectionManager.AddConnection(userName, connectionId,
            (u) => Clients.Others.UserConnected(u)
        );
        int count = _connectionManager.OnlineUsers.Count();
        await Clients.All.OnlineUsersCount(count);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        string userName = Context.User?.Identity?.Name
            ?? throw new Exception("User is not authenticated");

        string connectionId = Context.ConnectionId;
        _connectionManager.RemoveConnection(userName, connectionId,
            (u) => Clients.Others.UserDisconnected(u));
        int count = _connectionManager.OnlineUsers.Count();
        await Clients.All.OnlineUsersCount(count);
        await base.OnDisconnectedAsync(exception);
    }
    public int GetOnlineUsersCount()
    {
        return _connectionManager.OnlineUsers.Count();
    }
}

