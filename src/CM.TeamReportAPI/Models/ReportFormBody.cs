using System.ComponentModel.DataAnnotations;

namespace CM.TeamReportAPI.Models
{
    public class ReportFormBody
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int Morale { get; set; }

        [StringLength(255)]
        public string MoraleDescription { get; set; } = string.Empty;

        [Required]
        public int Stress { get; set; }

        [StringLength(255)]
        public string StressDescription { get; set; } = string.Empty;

        [Required]
        public int Workload { get; set; }

        [StringLength(255)]
        public string WorkloadDescription { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string High { get; set; }

        [Required]
        [StringLength(255)]
        public string Low { get; set; }

        [StringLength(255)]
        public string AnythingElse { get; set; } = string.Empty;

        [Required]
        public DateTime DateRangeStart{ get; set; }

        [Required]
        public DateTime DateRangeEnd { get; set; }
    }
}
