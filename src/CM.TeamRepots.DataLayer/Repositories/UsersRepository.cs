using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;

namespace CM.TeamRepots.DataLayer.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly TRDbContext _context;

        public UsersRepository()
        {
            _context = new TRDbContext();
        }

        public void Create(Users entity)
        {
            _context
                .Users
                .Add(entity);
            _context
                .SaveChanges();
        }

        public void Delete(int entityCode)
        {
            _context
                .Users
                .Remove(Read(entityCode));
            _context.SaveChanges();
        }

        public List<Users> GetAll()
        {
            var users = _context
                .Users
                .ToList();
            return users;
        }

        public List<Users> GetAll(int entityCode)
        {
            var users = _context
                .Users
                .Where(u => u.TeamId == entityCode).ToList();
            return users;
        }

        public Users Read(int entityCode)
        {
            var user = _context
                .Users
                .FirstOrDefault( u => u.UserId == entityCode);
            return user;
        }

        public Users Read(string email)
        {
            var user = _context
                .Users
                .FirstOrDefault(u => u.Email == email);
            return user;
        }

        public void Update(Users entity)
        {
            _context
                .Users
                .Update(entity);
            _context
                .SaveChanges();
        }

        public Users GetUserByEmail(string email)
        {
            return _context.
                Users.
                FirstOrDefault(c => c.Email == email);
        }
    }
}
