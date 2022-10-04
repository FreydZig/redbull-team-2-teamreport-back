using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;

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

        public void Delete(int entityCode)
        {
            _context
                .Reports
                .Remove(Read(entityCode));
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

        public List<Reports> GetAllByUserId(int entityCode)
        {
            var reports = _context
                .Reports
                .Where(r => r.UserId == entityCode)
                .ToList();

            return reports;
        }

        public Reports Read(int entityCode)
        {
            var report = _context
                .Reports
                .FirstOrDefault(r => r.ReportId == entityCode);
            
            return report;
        }

        public Reports ReadByUserId(int entityCode)
        {
            try
            {
                var report = _context
                    .Reports
                    .FirstOrDefault(r => r.UserId == entityCode && r.DateRange <= DateTime.Now && r.DateRange >= DateTime.Now.AddDays(-7));

                return report;
            }
            catch
            {
                return null;
            }
        }
         
        public Reports ReadByDate(DateTime date)
        {
            try
            {
                var report = _context
                   .Reports
                   .First(r => r.DateRange == date);

                return report;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int ReadByPeriod(DateTime start, DateTime end, int Id)
        {
            try
            {
                var report = _context
                   .Reports
                   .First(r => r.DateRange >= start && r.DateRange <= end && r.UserId == Id);

                return (report.Morale + report.Stress + report.Workload) / 3;
            }
            catch
            { 
                return 0;
            }
        }


        //Не трогать!!!!
        public void Update(Reports entity)
        {
            throw new NotImplementedException();
        }
    }
}
