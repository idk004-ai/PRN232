using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models.Entities;

[Table("tblNotifications")]
public class Notification : BaseEntity
{
    [MaxLength(50)]
    public required string Type { get; set; }
    [MaxLength(500)]
    public required string Message { get; set; }
    public bool IsRead { get; set; }
    public required virtual ApplicationUser Receiver { get; set; }
    public bool IsDeleted { get; set; }

}