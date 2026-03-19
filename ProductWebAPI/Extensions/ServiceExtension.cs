using Services;
using BusinessObjects.Interfaces.IRepositories;
using BusinessObjects.Interfaces.IServices;
using Repositories;
using ProductWebAPI.Hubs;
using ProductWebAPI.BackgroundServices;
using ProductWebAPI.Middlewares;
namespace ProductWebAPI.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection RegisterService(this IServiceCollection services)
    {
        services.AddScoped<ErrorHandlingMiddleware>();
        services.AddLogging();
        #region BackgroundServices
        services.AddSingleton<NotificationQueueService>();
        services.AddHostedService(sp => sp.GetService<NotificationQueueService>()!);
        services.AddSingleton<INotificationQueueService>(sp => sp.GetService<NotificationQueueService>()!);
        services.AddHostedService<MajorCleanupService>();
        services.AddHostedService<TopicCleanupService>();
        services.AddHostedService<PostCleanupService>();
        #endregion

        #region Connection
        services.AddSingleton<ConnectionManager>();
        #endregion

        #region Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IMajorService, MajorService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<IVoteService, VoteService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IFeedService, FeedService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IReportService, ReportService>();
        #endregion

        #region Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IMajorRepository, MajorRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>();
        services.AddScoped<IVoteRepository, VoteRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IFeedRepository, FeedRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        #endregion
        return services;
    }
}