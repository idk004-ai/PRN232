using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models.Entities;

[Table("tblComments")]
public class Comment : BaseEntity
{
    [MaxLength(2000)]
    public string Content { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public required virtual ApplicationUser Creater { get; set; }
    public required virtual Post Post { get; set; }
    public virtual Attachment? Attachment { get; set; }
    public virtual Comment? ReplyTo { get; set; }
    public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();
    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}