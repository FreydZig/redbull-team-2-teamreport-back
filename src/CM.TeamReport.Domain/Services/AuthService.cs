using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Data;
using CM.TeamReport.Domain.Exceptions;
using System.Security.Claims;

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
                    claims: new List<Claim>(){new Claim("firstName", user.FirstName),
                        new Claim("lastName", user.LastName),
                        new Claim("email", user.Email),
                        new Claim("title", user.Title),
                        new Claim("userId", user.UserId.ToString()),
                        new Claim("company", user.TeamId.ToString())
                    },
                    signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return  new JwtSecurityTokenHandler().WriteToken(jwt); 
            throw new NotImplementedException();
        }

        public async Task<Users> UserLogin(string email, string password)
        {
            var user = await _usersRepository.Read(email);
            if (user == null || user.Email == null)
            {
                throw new LoginException("Email isn't correct!");
            }
            var passwordSaltHash = user.Password.Split('.');
            byte[] passwordHash = Convert.FromBase64String(passwordSaltHash[1]);
            byte[] passwordSalt = Convert.FromBase64String(passwordSaltHash[0]);
            var passwordVerify = new PasswordHash();
            if (!passwordVerify.VerifyPasswordHash(password,passwordSalt, passwordHash))
            {
                throw new LoginException("Password isn't correct!");
            }
            return user;
        }
    }
}
