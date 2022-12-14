using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Interfaces;

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

        public async Task<List<OverallReports>> OverallReports(int TeamId)
        {
            var users = await _userRepository.GetAll(TeamId);

            var teamReports = new List<OverallReports>();

            foreach (var user in users)
            {
                var teamReport = new OverallReports();

                teamReport.Current = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now)), DateTime.Now.AddDays(7 - Utils.DayOfWeekToInt(DateTime.Now)), user.UserId);
                teamReport.ago9 = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 61), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 56), user.UserId);
                teamReport.ago8 = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 56), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 49), user.UserId);
                teamReport.ago7 = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 49), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 42), user.UserId);
                teamReport.ago6 = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 42), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 35), user.UserId);
                teamReport.ago5 = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 35), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 28), user.UserId);
                teamReport.ago4 = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 28), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 21), user.UserId);
                teamReport.ago3 = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 21), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 14), user.UserId);
                teamReport.ago2 = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 14), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 7), user.UserId);
                teamReport.ago1 = await _reportsRepository.SumOfUserStates(DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 7), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now)), user.UserId);

                teamReport.UserName = $"{user.FirstName} {user.LastName}";

                teamReports.Add(teamReport);
            }

            return teamReports;
        }

        public async Task<List<OverallReports>> StateSort(int TeamId, char state)
        {
            var users = await _userRepository.GetAll(TeamId);

            var teamReports = new List<OverallReports>();

            if(users != null)
            foreach (var user in users)
            {
                var teamReport = new OverallReports();

                teamReport.Current = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now)), DateTime.Now.AddDays(7 - Utils.DayOfWeekToInt(DateTime.Now)));
                teamReport.ago9 = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 61), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 56));
                teamReport.ago8 = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 56), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 49));
                teamReport.ago7 = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 49), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 42));
                teamReport.ago6 = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 42), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 35));
                teamReport.ago5 = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 35), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 28));
                teamReport.ago4 = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 28), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 21));
                teamReport.ago3 = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 21), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 14));
                teamReport.ago2 = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 14), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 7));
                teamReport.ago1 = await _reportsRepository.UserState(user.UserId, state, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 7), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now)));

                teamReport.UserName = string.Format("{0} {1}", user.FirstName, user.LastName);

                teamReports.Add(teamReport);
            }

            return  teamReports;
        }

        public async Task<List<PreviousReports>> PreviousReports(int TeamId)
        {
            var users = await _userRepository.GetAll(TeamId);

            List<PreviousReports> previousReports = new List<PreviousReports>();

            foreach (var user in users)
            {
                var previousReport = new PreviousReports();

                var report = await _reportsRepository.ReadByUserIdAndPeriod(user.UserId, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now)), DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now) - 7));

                previousReport.Name = $"{user.FirstName} {user.LastName}";

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

        public async Task<List<PreviousReports>> CurentReports(int TeamId)
        {
            var users = await _userRepository.GetAll(TeamId);

            List<PreviousReports> previousReports = new List<PreviousReports>();

            foreach (var user in users)
            {
                var previousReport = new PreviousReports();

                var report = await _reportsRepository.ReadByUserIdAndPeriod(user.UserId, DateTime.Now, DateTime.Now.AddDays(Utils.DayOfWeekToInt(DateTime.Now)));

                previousReport.Name = $"{user.FirstName} {user.LastName}";

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

        public async Task<bool> IsLeader(int UserId)
        {
            var leader = await _leadersRepository.Read(UserId);
            
            return leader != null;
        }

        
    }
}
