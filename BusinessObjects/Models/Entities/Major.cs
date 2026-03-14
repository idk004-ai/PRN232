using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models.Entities;

[Table("tblMajors")]
public class Major : BaseEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Description { get; set; } = string.Empty;
    [MaxLength(50)]
    public bool IsDeleted { get; set; } = false;
    public DateTime? DateDeleted { get; set; } 
    public ICollection<Profile> Profiles { get; set; } = new List<Profile>();
    public ICollection<Topic> Topics { get; set; } = new List<Topic>();
}