using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;

namespace CM.TeamRepots.DataLayer.Repositories
{
    public class TeamsRepository : IRepository<Teams>
    {
        private readonly TRDbContext _context;

        public TeamsRepository()
        {
            _context = new TRDbContext();
        }

        public void Create(Teams entity)
        {
            _context.Teams.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int entityCode)
        {
            throw new NotImplementedException();
        }

        public List<Teams> GetAll(int entityCode)
        {
            var list = _context.Teams.ToList();
            return list;
        }

        public Teams Read(int entityCode)
        {
            throw new NotImplementedException();
        }

        public void Update(Teams entity)
        {
            throw new NotImplementedException();
        }
    }
}
