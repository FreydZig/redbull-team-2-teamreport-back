using System.ComponentModel.DataAnnotations;

namespace CM.TeamReportAPI.Models
{
    public class InviteUser
    {
        
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
