using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Models
{
    public class InviteMember
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Link { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
    }
}
