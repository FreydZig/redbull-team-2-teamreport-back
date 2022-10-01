
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Data;

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
            if (user is null || user.Email is null)
            {
                throw new DataException("Data is empty!");
            }

            var jwt = new JwtSecurityToken(
                    issuer: JwtOptions.ISSUER,
                    audience: JwtOptions.AUDIENCE,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                    signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt); throw new NotImplementedException();
        }

        public Users UserLogin(string email, string password)
        {
            var user = _usersRepository.Read(email);
            if (user == null)
            {
                throw new DataException("Email isn't correct!");
            }
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
