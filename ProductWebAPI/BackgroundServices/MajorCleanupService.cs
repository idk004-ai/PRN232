using BusinessObjects.Constants;
using BusinessObjects.Interfaces.IRepositories;


namespace ProductWebAPI.BackgroundServices;

public class MajorCleanupService(IServiceProvider serviceProvider, ILogger<MajorCleanupService> logger) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly TimeSpan _period = TimeSpan.FromHours(Major.DATE_DELAY_HOURS);
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
        var majorRepository = scope.ServiceProvider.GetRequiredService<IMajorRepository>();
        var majors = await majorRepository.GetMajorByTrash();
        if (majors == null || !majors.Any())
        {
            _logger.LogInformation("No deleted majors found for cleanup.");
            return;
        }
        _logger.LogInformation($"Found {majors.Count()} deleted majors for cleanup.");
        await majorRepository.DeleteRange([.. majors]);
        _logger.LogInformation($"Permanently deleted {majors.Count()} majors.");
    }
}