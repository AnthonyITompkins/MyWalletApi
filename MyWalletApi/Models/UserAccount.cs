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
        [MaxLength(25, ErrorMessage = "Maximum password length is 25.")]
        public required string Password { get; set; }
    }
}
