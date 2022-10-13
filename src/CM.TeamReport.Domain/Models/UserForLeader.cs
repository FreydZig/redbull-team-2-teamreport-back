using System.ComponentModel.DataAnnotations;

namespace CM.TeamReport.Domain.Models
{
    public class UserForLeader
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string? Title { get; set; }
    }
}
