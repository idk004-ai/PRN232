using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessObjects.Constants;

namespace BusinessObjects.Models.Entities
{
    [Table("tblProfiles")]
    public class Profile : BaseEntity
    {
        [MaxLength(25)]
        public required string FirstName { get; set; }
        [MaxLength(25)]
        public required string LastName { get; set; }
        public Gender Gender { get; set; }
        [MaxLength(255)]
        public string Bio { get; set; } = string.Empty;
        [MaxLength(25)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Avatar { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Banner { get; set; } = string.Empty;
        public required virtual ApplicationUser User { get; set; }
        public required virtual Major Major { get; set; }
    }
}