using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Models
{
    public class LocalUser
    {
        [Key]
        public string UserId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
