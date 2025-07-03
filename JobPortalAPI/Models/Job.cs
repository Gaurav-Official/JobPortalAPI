namespace JobPortalAPI.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string CompanyName { get; set; }
        public string JobType { get; set; } // Full-time, Part-time
        public DateTime PostedDate { get; set; }
    }
}
