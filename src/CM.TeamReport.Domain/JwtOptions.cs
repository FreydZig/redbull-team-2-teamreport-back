using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CM.TeamReport.Domain
{
    public class JwtOptions
    {
        //test
        public const string ISSUER = "FromBack";
        public const string AUDIENCE = "TeamReports";
        const string KEY = "It_lies_under_the_rug";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
