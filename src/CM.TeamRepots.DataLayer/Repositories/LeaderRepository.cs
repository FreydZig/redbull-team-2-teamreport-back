using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;

namespace CM.TeamRepots.DataLayer.Repositories
{
    public class LeaderRepository : ILeaderRepository
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
            var user = Read(entityCode);
            if (user != null)
            {
                _context
                    .Leaders
                    .Remove(user);
                _context
                    .SaveChanges();
            }
        }

        public void Delete(int userId, int teamId)
        {
            var team = ReadByTeamId(teamId);
            if (team != null)
            {
                _context
                    .Leaders
                    .Remove(team);
                _context
                    .SaveChanges();
            }
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
                .FirstOrDefault(l => l.UserId == entityCode);

            return leader;
        }

        public Leaders ReadByTeamId(int teamId)
        {
            var leader = _context
                .Leaders
                .FirstOrDefault(l => l.TeamId == teamId);

            return leader;
        }

        //НЕ ТРОГАТЬ!!!!!!!!!!!!
        public void Update(Leaders entity)
        {
            throw new NotImplementedException();
        }
    }
}
