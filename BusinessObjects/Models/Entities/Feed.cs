using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models.Entities;

[Table("tblFeeds")]
public class Feed : BaseEntity
{
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Description { get; set; } = string.Empty;
    public virtual ApplicationUser? Creater { get; set; }
    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();

}