using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async void Delete(int entityCode)
        {
            _context
                .Users
                .Remove(await Read(entityCode));
            _context.SaveChanges();
        }

        public List<Users> GetAll()
        {
            var users = _context
                .Users
                .ToList();
            return users;
        }

        public async Task<List<Users>> GetAll(int entityCode)
        {
            var users = await _context
                .Users
                .Where(u => u.TeamId == entityCode).ToListAsync();
            return users;
        }

        public async Task<Users> Read(int entityCode)
        {
            return await _context
                .Users
                .FirstOrDefaultAsync(u => u.UserId == entityCode);
        }

        public async Task<Users> Read(string email)
        {
            return await _context
                        .Users
                        .FirstOrDefaultAsync(u => u.Email == email);
        }

        public void Update(Users entity)
        {
            _context
                .Users
                .Update(entity);
            _context
                .SaveChanges();
        }
    }
}
