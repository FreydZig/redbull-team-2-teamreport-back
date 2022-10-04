using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services
{
    public class LeaderService : ILeaderSevice
    {
        private readonly IUserRepository _userRepository;
        private readonly IReportsRepository _reportsRepository; 

        public LeaderService(IUserRepository userRepository, IReportsRepository reportsRepository)
        {
            _userRepository = userRepository;
            _reportsRepository = reportsRepository;
        }

        //public void InviteTeam(string email, int TeamId)
        //{
        //    var user = _userRepository.Read(email);

        //    user.TeamId = TeamId;

        //    _userRepository.Update(user);
        //}

        public List<OverallReports> OverallReports(int TeamId)
        {
            var users = _userRepository.GetAll(TeamId);

            List<OverallReports> teamReports = new List<OverallReports>();

            foreach (var user in users)
            {
                var teamReport = new OverallReports();

                teamReport.Current = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-7), DateTime.Now, user.UserId);
                teamReport.ago9 = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-79), DateTime.Now.AddDays(-72), user.UserId);
                teamReport.ago8 = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-71), DateTime.Now.AddDays(-64), user.UserId);
                teamReport.ago7 = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-63), DateTime.Now.AddDays(-56), user.UserId);
                teamReport.ago6 = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-55), DateTime.Now.AddDays(-48), user.UserId);
                teamReport.ago5 = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-47), DateTime.Now.AddDays(-40), user.UserId);
                teamReport.ago4 = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-39), DateTime.Now.AddDays(-32), user.UserId);
                teamReport.ago3 = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-31), DateTime.Now.AddDays(-24), user.UserId);
                teamReport.ago2 = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-23), DateTime.Now.AddDays(-16), user.UserId);
                teamReport.ago1 = _reportsRepository.ReadByPeriod(DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-8), user.UserId);

                teamReport.UserName = user.FirstName + ' ' + user.LastName; 

                teamReports.Add(teamReport);
            }

            return  teamReports;
        }

        public List<PreviousReports> PreviousReports(int TeamId)
        {
            var users = _userRepository.GetAll(TeamId);

            List<PreviousReports> previousReports = new List<PreviousReports>();

            foreach (var user in users)
            {
                var previousReport = new PreviousReports();

                var report = _reportsRepository.ReadByUserId(user.UserId);

                previousReport.Name = user.FirstName + ' ' + user.LastName;

                if (report != null)
                {         
                    previousReport.Morale = report.Morale;
                    previousReport.Workload = report.Workload;
                    previousReport.Stress = report.Stress;
                }

                previousReports.Add(previousReport);
            }

            return previousReports;
        }
    }
}
