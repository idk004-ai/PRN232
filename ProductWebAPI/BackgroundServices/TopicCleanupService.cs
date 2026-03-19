using BusinessObjects.Constants;
using BusinessObjects.Interfaces.IRepositories;

namespace ProductWebAPI.BackgroundServices;

public class TopicCleanupService(IServiceProvider serviceProvider, ILogger<MajorCleanupService> logger) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly TimeSpan _period = TimeSpan.FromHours(Topic.DATE_DELAY_HOURS);
    private readonly ILogger<MajorCleanupService> _logger = logger;
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await DoWork();
            await Task.Delay(_period, stoppingToken);
        }
    }

    private async Task DoWork()
    {
        using var scope = _serviceProvider.CreateScope();
        var topicRepository = scope.ServiceProvider.GetRequiredService<ITopicRepository>();
        var topics = await topicRepository.GetTopicsByTrash();
        if (topics == null || !topics.Any())
        {
            _logger.LogInformation("No deleted topics found for cleanup.");
            return;
        }
        _logger.LogInformation($"Found {topics.Count()} deleted topics for cleanup.");
        await topicRepository.DeleteRange([.. topics]);
        _logger.LogInformation($"Permanently deleted {topics.Count()} topics.");
    }
}