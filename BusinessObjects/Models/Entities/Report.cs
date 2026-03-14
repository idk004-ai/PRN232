using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models.Entities;

[Table("tblReports")]
public class Report : BaseEntity
{
    [MaxLength(50)]
    public string Type { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string Content { get; set; } = string.Empty;
    public bool IsRejected { get; set; } = false;
    [MaxLength(500)]
    public string? ResponseContent { get; set; } = string.Empty;
    public required virtual ApplicationUser Creater { get; set; }

}