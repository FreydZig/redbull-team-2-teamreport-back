using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Models
{
    public class PreviousReports
    {
        public string Name { get; set; }

        public int Morale { get; set; } = 0;

        public int Stress { get; set; } = 0;

        public int Workload { get; set; } = 0;
    }
}
