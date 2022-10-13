using DataAnnotationsExtensions;

namespace CM.TeamReportAPI.Models
{
    public class UserCreateModel
    {

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }

        public int TeamId { get; set; }
        
        [Email]
        public string Email { get; set; }

        public string? Title { get; set; }

        public string Password { get; set; }
    }
}
