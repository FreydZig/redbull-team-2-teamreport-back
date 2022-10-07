using System.ComponentModel.DataAnnotations;

namespace CM.TeamRepots.DataLayer.Entity
{
    public class Users
    {
        [Required]
        [Key]
        public int UserId { get; set; }

        public int? TeamId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        public string? Title { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
