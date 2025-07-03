namespace JobPortalAPI.Models.DTOs
{
    public class JobApplicationCreateDto
    {
        public string ApplicantName { get; set; }
        public string Email { get; set; }
        public string ResumeUrl { get; set; }
        public int JobId { get; set; }
    }
}
