using System.ComponentModel.DataAnnotations;

namespace CM.TeamRepots.DataLayer.Entity
{
    public class Leaders
    {
        [Required]
        [Key]
        public int LeaderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int TeamId { get; set; }
    }
}
