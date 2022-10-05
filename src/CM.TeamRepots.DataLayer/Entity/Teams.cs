using System.ComponentModel.DataAnnotations;

namespace CM.TeamRepots.DataLayer.Entity
{
    public class Teams
    {
        [Required]
        [Key]
        public int TeamId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string TeamName { get; set; }
    }
}
