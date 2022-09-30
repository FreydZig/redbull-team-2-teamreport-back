
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using CM.TeamRepots.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _usersRepository;
        public AuthService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public string GetToken(Users user)
        {
            throw new NotImplementedException();
        }

        public Users UserLogin(string email, string password)
        {
            var user = _usersRepository.GetUserByEmail(email);
            var passwordSaltHash = user.Password.Split('.');
            var passwordVerify = new PasswordHash();
            if (!passwordVerify.VerifyPasswordHash(password, Encoding.ASCII.GetBytes(passwordSaltHash[0]), Encoding.ASCII.GetBytes(passwordSaltHash[1])))
            {
                throw new Exception();
                //TODO: add Exception
            }
            return user;
        }
    }
}
