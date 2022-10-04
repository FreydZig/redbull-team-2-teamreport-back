using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Models
{
    public class OverallReports
    {
        public string UserName { get; set; }

        public int ago9 { get; set; } = 0;

        public int ago8 { get; set; } = 0;

        public int ago7 { get; set; } = 0;

        public int ago6 { get; set; } = 0;

        public int ago5 { get; set; } = 0;

        public int ago4 { get; set; } = 0;

        public int ago3 { get; set; } = 0;

        public int ago2 { get; set; } = 0;

        public int ago1 { get; set; } = 0;

        public int Current { get; set; } = 0;
    }
}
