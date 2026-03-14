using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models.Entities
{
    [Table("tblRecentPosts")]
    public class RecentPost : BaseEntity
    {
        public required virtual ApplicationUser User { get; set; }
        public required virtual Post Post { get; set; }
    }
}