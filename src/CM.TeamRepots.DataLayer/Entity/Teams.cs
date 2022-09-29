using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamRepots.DataLayer.Entity
{
    public class Teams
    {
        [Required]
        [Key]
        public int TeamId { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string TeamName { get; set; }
    }
}
