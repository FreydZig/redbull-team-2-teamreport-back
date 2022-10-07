using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async void Delete(int entityCode)
        {
            _context
                .Teams
                .Remove(await Read(entityCode));
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

        public async Task<Teams> Read(int entityCode)
        {
            return await _context
                .Teams
                .FirstOrDefaultAsync(t => t.TeamId == entityCode);
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
