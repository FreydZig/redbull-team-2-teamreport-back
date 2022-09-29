using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;

namespace CM.TeamRepots.DataLayer.Repositories
{
    public class ReportsRepository : IRepository<Reports>
    {
        private readonly TRDbContext _context;

        public ReportsRepository()
        {
            _context = new TRDbContext();
        }

        public void Create(Reports entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityCode)
        {
            throw new NotImplementedException();
        }

        public List<Reports> GetAll()
        {
            throw new NotImplementedException();
        }

        public Reports Read(int entityCode)
        {
            throw new NotImplementedException();
        }

        public void Update(Reports entity)
        {
            throw new NotImplementedException();
        }
    }
}
