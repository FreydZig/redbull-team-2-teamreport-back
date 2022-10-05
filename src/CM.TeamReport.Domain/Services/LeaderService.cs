using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
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
        private readonly ILeaderRepository _leadersRepository; 

        public LeaderService(IUserRepository userRepository, IReportsRepository reportsRepository, ILeaderRepository leadersRepository)
        {
            _userRepository = userRepository;
            _reportsRepository = reportsRepository;
            _leadersRepository = leadersRepository;
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

                teamReport.Current = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now)), DateTime.Now, user.UserId);
                teamReport.ago9 = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 61), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 56), user.UserId);
                teamReport.ago8 = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 56), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 49), user.UserId);
                teamReport.ago7 = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 49), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 42), user.UserId);
                teamReport.ago6 = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 42), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 35), user.UserId);
                teamReport.ago5 = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 35), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 28), user.UserId);
                teamReport.ago4 = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 28), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 21), user.UserId);
                teamReport.ago3 = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 21), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 14), user.UserId);
                teamReport.ago2 = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 14), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 7), user.UserId);
                teamReport.ago1 = _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 7), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now)), user.UserId);

                teamReport.UserName = user.FirstName + ' ' + user.LastName; 

                teamReports.Add(teamReport);
            }

            return  teamReports;
        }

        public List<OverallReports> StateSort(int TeamId, char state)
        {
            var users = _userRepository.GetAll(TeamId);

            List<OverallReports> teamReports = new List<OverallReports>();

            foreach (var user in users)
            {
                var teamReport = new OverallReports();

                teamReport.Current = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now)), DateTime.Now);
                teamReport.ago9 = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 61), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 56));
                teamReport.ago8 = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 56), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 49));
                teamReport.ago7 = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 49), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 42));
                teamReport.ago6 = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 42), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 35));
                teamReport.ago5 = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 35), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 28));
                teamReport.ago4 = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 28), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 21));
                teamReport.ago3 = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 21), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 14));
                teamReport.ago2 = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 14), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 7));
                teamReport.ago1 = _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 7), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now)));

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

                var report = _reportsRepository.ReadByUserIdAndPeriod(user.UserId, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now)), DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now) - 7));

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

        public List<PreviousReports> CurentReports(int TeamId)
        {
            var users = _userRepository.GetAll(TeamId);

            List<PreviousReports> previousReports = new List<PreviousReports>();

            foreach (var user in users)
            {
                var previousReport = new PreviousReports();

                var report = _reportsRepository.ReadByUserIdAndPeriod(user.UserId, DateTime.Now, DateTime.Now.AddDays(DayOfWeekToInt(DateTime.Now)));

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

        public bool IsLeader(int UserId)
        {
            var leader = _leadersRepository.Read(UserId);
            
            return leader != null;
        }

        private int DayOfWeekToInt(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday: return -1;
                case DayOfWeek.Tuesday: return -2;
                case DayOfWeek.Wednesday: return -3;
                case DayOfWeek.Thursday: return -4;
                case DayOfWeek.Friday: return -5;
                case DayOfWeek.Saturday: return -6;
                case DayOfWeek.Sunday: return -7;
                default: return 0;
            } 
        }
    }
}
