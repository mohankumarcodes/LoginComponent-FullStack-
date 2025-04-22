using System.ComponentModel.DataAnnotations;

namespace LoginApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; } // Hashed password in a real-world scenario
    }
}
