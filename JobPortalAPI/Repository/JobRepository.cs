using JobPortalAPI.Data;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;

        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            return await _context.Jobs.OrderByDescending(j => j.PostedDate).ToListAsync();
        }

        public async Task<Job> GetJobAsync(int jobId)
        {
            return await _context.Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
        }

        public async Task<bool> CreateJobAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
            return await SaveAsync();
        }

        public async Task<bool> UpdateJobAsync(Job job)
        {
            _context.Jobs.Update(job);
            return await SaveAsync();
        }

        public async Task<bool> DeleteJobAsync(Job job)
        {
            _context.Jobs.Remove(job);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        IEnumerable<Job> IJobRepository.GetJobs(int pageNumber, int pageSize)
        {
            return _context.Jobs
        .OrderByDescending(j => j.PostedDate)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
        }

        int IJobRepository.GetJobCount()
        {
            return _context.Jobs.Count();
        }
    }
}
