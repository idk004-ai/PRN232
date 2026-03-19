using BusinessObjects.Constants;
using BusinessObjects.Interfaces.IRepositories;

namespace ProductWebAPI.BackgroundServices;

public class PostCleanupService(IServiceProvider serviceProvider, ILogger<MajorCleanupService> logger) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly ILogger<MajorCleanupService> _logger = logger;
    private readonly TimeSpan _period = TimeSpan.FromHours(Post.DATE_DELAY_HOURS); 
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
        var postRepository = scope.ServiceProvider.GetRequiredService<IPostRepository>();
        var pots = await postRepository.GetPostsByTrash();
        if (pots == null || !pots.Any())
        {
            _logger.LogInformation("No deleted topics found for cleanup.");
            return;
        }
        _logger.LogInformation($"Found {pots.Count()} deleted posts for cleanup.");
        await postRepository.DeleteRange([.. pots]);
        _logger.LogInformation($"Permanently deleted {pots.Count()} posts.");
    }
}