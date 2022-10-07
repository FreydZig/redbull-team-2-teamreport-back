using CM.TeamReport.Domain.Models;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface IEmailService
    {
        public void SendEmail(InviteMember request);
    }
}
