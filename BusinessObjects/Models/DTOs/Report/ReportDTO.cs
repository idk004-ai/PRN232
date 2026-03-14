using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models.DTOs.Report;
public class ReportDTO
{
    public Guid Id { get; set; }
    [MinLength(1, ErrorMessage = "Type cannot be empty")]
    public string Type { get; set; } = string.Empty;
    public ReportContent Content { get; set; } = new ReportContent();
    public string ReportedPostTitle { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string? ResponseContent { get; set; } = string.Empty;
    public string Creater { get; set; } = string.Empty;
}
