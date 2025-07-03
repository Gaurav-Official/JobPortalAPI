using JobPortalAPI.Models;

namespace JobPortalAPI.Repository.IRepository
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetJobsAsync();
        Task<Job> GetJobAsync(int jobId);

        Task<bool> CreateJobAsync(Job job);
        Task<bool> UpdateJobAsync(Job job);
        Task<bool> DeleteJobAsync(Job job);
        IEnumerable<Job> GetJobs(int pageNumber, int pageSize);
        int GetJobCount();


        Task<bool> SaveAsync();
    }
}
