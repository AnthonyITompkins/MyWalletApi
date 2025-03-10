using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyWalletApi.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserAccount
    {
        public int UserAccountId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage ="Maximum email length is 100.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }

        public required string PasswordSalt { get; set; }

        public bool Active { get; set; } = false;

        public DateTime RecordDate { get; set; }
    }
}
