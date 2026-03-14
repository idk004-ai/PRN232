using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models.Entities;

[Table("tblPosts")]
public class Post : BaseEntity
{
    [MaxLength(250)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(5000)]
    public string Content { get; set; } = string.Empty;
    [DefaultValue(true)]
    public bool IsApproved { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateTime? DateDeleted { get; set; }
    public virtual Topic? Topic { get; set; }
    public virtual required ApplicationUser Creater { get; set; }
    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    public virtual IEnumerable<SavedPost> SavedByUsers { get; set; } = new List<SavedPost>();
    public virtual IEnumerable<RecentPost> RecentViews { get; set; } = new List<RecentPost>();
}