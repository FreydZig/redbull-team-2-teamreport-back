using DataAnnotationsExtensions;

namespace CM.TeamReportAPI.Models
{
    public class UserCreateModel
    {
        //public int TeamId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }
        
        [Email]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
