using AutoMapper;
using JobPortalAPI.Models;
using JobPortalAPI.Models.DTOs;
using JobPortalAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepo;

        public JobsController(IJobRepository jobRepo, IMapper mapper)
        {
            _jobRepo = jobRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobRepo.GetJobsAsync();
            var jobDtos = _mapper.Map<IEnumerable<JobDto>>(jobs);
            return Ok(jobs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await _jobRepo.GetJobAsync(id);
            if (job == null) return NotFound();
            return Ok(job);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Employer")]
        public async Task<IActionResult> PostJob([FromBody] JobCreateDto jobCreateDto)
        {
            if (jobCreateDto == null) return BadRequest();
            var job = _mapper.Map<Job>(jobCreateDto);
            job.PostedDate = DateTime.Now;

            var result = await _jobRepo.CreateJobAsync(job);
            if (!result) return StatusCode(500, "Failed to create job");

            var jobDto = _mapper.Map<JobDto>(job);
            return Ok(jobDto);
        }

        [HttpPut("{id:int}")]
        //[Authorize(Roles = "Admin,Employer")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] Job job)
        {
            if (job == null || id != job.Id) return BadRequest();

            var result = await _jobRepo.UpdateJobAsync(job);
            if (!result) return StatusCode(500, "Failed to update job");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        //[Authorize(Roles = "Admin,Employer")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _jobRepo.GetJobAsync(id);
            if (job == null) return NotFound();

            var result = await _jobRepo.DeleteJobAsync(job);
            if (!result) return StatusCode(500, "Failed to delete job");

            return NoContent();
        }
        [HttpGet("paginated")]
        public IActionResult GetJobsPaginated(int pageNumber = 1, int pageSize = 10)
        {
            var jobs = _jobRepo.GetJobs(pageNumber, pageSize);
            var totalJobs = _jobRepo.GetJobCount();

            var response = new
            {
                TotalRecords = totalJobs,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Jobs = jobs
            };

            return Ok(response);
        }

    }
}
