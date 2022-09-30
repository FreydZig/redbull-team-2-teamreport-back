using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;

namespace CM.TeamRepots.DataLayer.Repositories
{
    public class LeaderRepository : IRepository<Leaders>
    {
        private readonly TRDbContext _context;

        public LeaderRepository()
        {
            _context = new TRDbContext();
        }

        public void Create(Leaders entity)
        {
            _context
                .Leaders
                .Add(entity);
            _context
                .SaveChanges();
        }

        public void Delete(int entityCode)
        {
            _context
                .Leaders
                .Remove(Read(entityCode));
            _context
                .SaveChanges();
        }

        public List<Leaders> GetAll()
        {
            var leaders = _context
                .Leaders
                .ToList();

            return leaders;
        }

        public Leaders Read(int entityCode)
        {
            var leader = _context
                .Leaders
                .FirstOrDefault(l => l.LeaderId == entityCode);

            return leader;
        }

        //НЕ ТРОГАТЬ!!!!!!!!!!!!
        public void Update(Leaders entity)
        {
            throw new NotImplementedException();
        }
    }
}
