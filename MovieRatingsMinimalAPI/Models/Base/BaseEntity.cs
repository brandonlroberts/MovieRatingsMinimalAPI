using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRatingsMinimalAPI.Models.Base
{
    public abstract class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Timestamp] public byte[] TimeStamp { get; set; } = new byte[0];
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

        [Display(Name = "IS ACTIVE")]
        public bool IsActive { get; set; }

    }
}
