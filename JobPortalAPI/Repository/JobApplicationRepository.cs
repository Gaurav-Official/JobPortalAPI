using JobPortalAPI.Data;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Repository
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
       private readonly ApplicationDbContext _context;
        public JobApplicationRepository(ApplicationDbContext context )
        {
                        _context = context;
        }
        public async Task<bool> ApplyForJob(JobApplication application)
        {
           await _context.JobApplications.AddAsync(application);
            return await SaveAsync();
        }

        public async Task<ICollection<JobApplication>> GetApplicationsForJob(int jobId)
        {
            return await _context.JobApplications.Where(j=>j.JobId == jobId)
                .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync()>0;
        }
    }
}
