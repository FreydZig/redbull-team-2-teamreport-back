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
            _context
                .Teams
                .Add(entity);
            _context
                .SaveChanges();
        }

        public void Delete(int entityCode)
        {
            _context
                .Teams
                .Remove(Read(entityCode));
            _context
                .SaveChanges();
        }

        public List<Teams> GetAll()
        {
            var teams = _context
                .Teams
                .ToList();
            return teams;
        }

        public Teams Read(int entityCode)
        {
            var team = _context
                .Teams
                .FirstOrDefault(t => t.TeamId == entityCode);
            return team;
        }

        public void Update(Teams entity)
        {
            _context
                .Teams
                .Update(entity);
            _context
                .SaveChanges();
        }
    }
}
