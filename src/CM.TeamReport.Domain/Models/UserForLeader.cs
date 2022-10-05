using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Models
{
    public class UserForLeader
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
