using BusinessObjects.Constants;
using ProductWebAPI.Hubs;
using ProductWebAPI.Middlewares;

namespace ProductWebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureApplication(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(Policy.SINGLE_PAGE_APP);
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.MapHub<NotificationHub>("/hubs/notification");
            return app;
        }
    }
}
