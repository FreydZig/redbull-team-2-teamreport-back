using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CM.TeamRepots.DataLayer.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly TRDbContext _context;

        public ReportsRepository()
        {
            _context = new TRDbContext();
        }

        public void Create(Reports entity)
        {
            _context
                .Reports
                .Add(entity);
            _context
                .SaveChanges();
        }

        public async void Delete(int entityCode)
        {
            _context
                .Reports
                .Remove( await Read(entityCode));
            _context
                .SaveChanges();
        }

        public List<Reports> GetAll()
        {
            var reports = _context
                .Reports
                .ToList();
            return reports;
        }

        public List<Reports> GetAllByTeamId(int entityCode)
        {
            List<Reports> result = new List<Reports>();

            var users = _context
                .Users
                .Where(u => u.TeamId == entityCode)
                .ToList();

            foreach(var user in users)
            {
                var reports = _context
                    .Reports
                    .Where(r => r.UserId == user.UserId)
                    .ToList();
                result.AddRange(reports);

            }
            
            return result;
        }

        public async Task<List<Reports>> GetAllByUserId(int entityCode)
        {
            var reports = await _context
                .Reports
                .Where(r => r.UserId == entityCode)
                .ToListAsync();

            return reports;
        }

        public async Task<Reports> Read(int entityCode)
        {
            return await _context
                .Reports
                .FirstOrDefaultAsync(r => r.ReportId == entityCode);
        }

        public async Task<Reports> ReadByUserIdAndPeriod(int entityCode, DateTime start, DateTime end)
        {
            var report = await _context
                    .Reports
                    .FirstOrDefaultAsync
                    (r => 
                        r.UserId == entityCode
                        && 
                        r.DateRangeStart <= start 
                        &&
                        r.DateRangeEnd >= end
                    );

            return report;
        }

        public async Task<int> UserState(int entityCode, char state, DateTime start, DateTime end)
        {
            var report = await _context
                    .Reports
                    .FirstOrDefaultAsync
                    (r =>
                        r.UserId == entityCode
                        &&
                        r.DateRangeStart <= end
                        &&
                        r.DateRangeEnd >= start
                    );
            if(report == null) return 0;

            switch (state)
            {
                case 'M': return report.Morale;
                case 'S': return report.Stress;
                case 'W': return report.Workload;
                default: return 0;
            }
        }

            
        public async Task<int> SumOfUserStates(DateTime start, DateTime end, int Id)
        {
            var report = await _context
                   .Reports
                   .FirstOrDefaultAsync
                   (r =>
                        r.DateRangeStart >= start
                        &&
                        r.DateRangeEnd <= end
                        &&
                        r.UserId == Id
                    );

            if(report != null)
            return (report.Morale + report.Stress + report.Workload) / 3;

            return 0;
        }


        //Не трогать!!!!
        public void Update(Reports entity)
        {
            throw new NotImplementedException();
        }
    }
}
