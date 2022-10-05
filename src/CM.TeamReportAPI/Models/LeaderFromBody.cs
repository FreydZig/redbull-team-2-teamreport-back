using System.ComponentModel.DataAnnotations;

namespace CM.TeamReportAPI.Models
{
    public class LeaderFromBody
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int TeamId { get; set; }
    }
}
