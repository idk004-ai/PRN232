using Newtonsoft.Json;
using ProductWebAPI.Hubs;
using BusinessObjects.Interfaces.IServices;

namespace ProductWebAPI.BackgroundServices;
public class PostMonitoringService(
        NotificationQueueService notificationQueueService,
        IServiceProvider serviceProvider,
        ConnectionManager connectionManager) : BackgroundService
{
    private const int TIME_INTERVAL = 1;
    private readonly NotificationQueueService _notificationQueueService = notificationQueueService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly ConnectionManager _connectionManager = connectionManager;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var postService = scope.ServiceProvider.GetRequiredService<IPostService>();
                var topicService = scope.ServiceProvider.GetRequiredService<ITopicService>();
                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

                var newPosts = await postService
                    .GetPostsByTime(DateTime.Now.AddMinutes(-1 * TIME_INTERVAL), DateTime.Now);
                var postsByTopic = newPosts
                    .Where(p => p.TopicName != null)
                    .GroupBy(post => post.TopicName)
                    .ToList();
                foreach (var group in postsByTopic)
                {
                    var authors = group.Select(post => post.Author).Distinct().ToList();
                    var message = JsonConvert.SerializeObject(new
                    {
                        Avatar = group.First().TopicAvatar,
                        Message = (authors.Count > 3 ? $"<{authors[0]}, {authors[1]}, and {authors.Count - 2} others>" : $"<{string.Join(", ", authors)}>")
                            + $" posted in topic <{group.Key}>",
                        Sender = group.Key,
                        Link = "/topic/" + group.Key
                    });
                }
            }
            await Task.Delay(TimeSpan.FromMinutes(TIME_INTERVAL), stoppingToken);
        }
    }
}