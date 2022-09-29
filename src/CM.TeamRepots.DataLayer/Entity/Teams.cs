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
        public int TeamId { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public int TeamName { get; set; }
    }
}
