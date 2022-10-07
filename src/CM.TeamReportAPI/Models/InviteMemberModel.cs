using System.ComponentModel.DataAnnotations;

namespace CM.TeamReportAPI.Models
{
    public class InviteMemberModel
    {
        
        public string FirstName { get; set; } = string.Empty;

        public string Link { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
