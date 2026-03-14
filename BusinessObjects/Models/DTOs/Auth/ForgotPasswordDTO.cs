using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models.DTOs.Auth;

public class ForgotPasswordDTO
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
}