using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamRepots.DataLayer.Entity
{
    public class Leaders
    {
        [Required]
        public int LiderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int TeamId { get; set; }
    }
}
