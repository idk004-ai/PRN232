using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models.Entities;

[Table("tblAttachments")]
public class Attachment : BaseEntity
{
    [MaxLength(50)]
    public required string Type { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public int Size { get; set; }
    [MaxLength(255)]
    public string Url { get; set; } = string.Empty;
    public required virtual Post Post { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

}