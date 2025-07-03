using JobPortalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }  
       public DbSet<Job> Jobs { get; set; }
       public DbSet<User> Users{ get; set; }
       public DbSet<JobApplication> JobApplications{ get; set; }
    }
}
