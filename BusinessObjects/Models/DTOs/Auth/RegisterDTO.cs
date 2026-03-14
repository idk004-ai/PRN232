using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models.DTOs.Auth;

public class RegisterDTO
{
    [Required(ErrorMessage = "Email cannot be empty")]
    [StringLength(256, ErrorMessage = "Email cannot exceed 256 characters")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password cannot be empty")]
    [StringLength(100, MinimumLength = 6,
    ErrorMessage = "Password must be between 6 and 100 characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?\"":{}|<>]).{6,}$",
    ErrorMessage = "Password must contain at least 1 uppercase letter, 1 lowercase letter, 1 number, and 1 special character")]
    public string Password { get; set; } = string.Empty;
}