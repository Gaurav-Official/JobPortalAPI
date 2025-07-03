using JobPortalAPI.Models;

namespace JobPortalAPI.Repository.IRepository
{
    public interface IJobApplicationRepository
    {

        Task<bool> ApplyForJob(JobApplication application);
        Task<ICollection<JobApplication>> GetApplicationsForJob(int jobId);
        Task<bool> SaveAsync();
    }
}
