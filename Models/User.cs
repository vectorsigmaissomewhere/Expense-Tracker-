using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Cashy.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        public string Password { get; set; } = string.Empty;
        //[Required(ErrorMessage = "Currency type is required.")]
        public string CurrencyType { get; set; } = string.Empty;
    }
}

