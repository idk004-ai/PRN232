using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Models.Entities;

[Table("tblTopics")]
[Index(nameof(Name), IsUnique = true)]
public class Topic : BaseEntity
{
    [MaxLength(25)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Description { get; set; } = string.Empty;
    [DefaultValue(false)]
    public bool NeedReview { get; set; }
    [MaxLength(300)]
    public string Panner { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Avatar { get; set; } = string.Empty;
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
    public DateTime? DateDeleted { get; set; }
    public ICollection<Major> Majors { get; set; } = new List<Major>();
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public virtual ICollection<ApplicationUser> ModeratedByUsers { get; set; } = new List<ApplicationUser>();
    public virtual ICollection<TopicBan> BannedUser { get; set; } = new List<TopicBan>();
    public virtual ICollection<Feed> Feeds { get; set; } = new List<Feed>();
}