namespace JobPortalAPI.Models
{
    public class JobApplication
    {
        public int Id { get; set; }                  // Primary Key
        public string ApplicantName { get; set; }    // Name of applicant
        public string Email { get; set; }            // Email of applicant
        public string ResumeUrl { get; set; }        // Link to resume
        public DateTime AppliedOn { get; set; }      // Date of application

        // Relationship to Job
        public int JobId { get; set; }               // Foreign key for Job
        public Job Job { get; set; }
    }
}
