namespace CM.TeamReportAPI.Models
{
    public class EditUserInformationModel
    {
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public int? TeamId { get; set; } = null;
    }
}
