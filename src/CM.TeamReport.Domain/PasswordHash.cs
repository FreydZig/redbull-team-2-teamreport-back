using System.Security.Cryptography;

namespace CM.TeamReport.Domain
{
    public class PasswordHash
    {
        public (byte[] salt, byte[] hash) CreatePasswordHash(string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return (passwordSalt, passwordHash);
        }

        public bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash )
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }

        }
    }
}