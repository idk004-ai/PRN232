using Microsoft.AspNetCore.Http;

namespace BusinessObjects.Interfaces.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
        Task<string> SendEmailConfirmationAsync(string email, HttpRequest request);
        Task<string> SendEmailConfirmationForgotPasswordAsync(string email, HttpRequest request);
    }
}