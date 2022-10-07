using CM.TeamReport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface IEmailService
    {
        public void SendEmail(InviteMember request);
    }
}
