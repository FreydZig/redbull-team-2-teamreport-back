using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamRepots.DataLayer.Entity
{
    public class Reports
    {
        [Required]
        [Key]
        public int ReportId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int Morale { get; set; }

        [StringLength(255)]
        public string MoraleDescription { get; set; }

        [Required]
        public int Stress { get; set; }

        [StringLength(255)]
        public string StressDescription { get; set; }

        [Required]
        public int Workload { get; set; }

        [StringLength(255)]
        public string WorkloadDescription { get; set; }

        [Required]
        [StringLength(255)]
        public string High { get; set; }

        [Required]
        [StringLength(255)]
        public string Low { get; set; }

        [StringLength(255)]
        public string AnythingElse { get; set; }

        [Required]  
        public DateTime DateRange { get; set; }

    }
}
