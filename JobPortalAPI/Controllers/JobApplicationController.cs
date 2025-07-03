using AutoMapper;
using JobPortalAPI.Models;
using JobPortalAPI.Models.DTOs;
using JobPortalAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : Controller
    {
        private readonly IJobApplicationRepository _jobApplication;
        private readonly IMapper _mapper;
        public JobApplicationController(IJobApplicationRepository jobApplication,IMapper mapper)
        {
            _jobApplication = jobApplication;            
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetApplication(int jobId)
        {
            var application = await _jobApplication.GetApplicationsForJob(jobId);
            return Ok(application);
        }



        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Apply([FromBody] JobApplicationCreateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var application = _mapper.Map<JobApplication>(dto);
            application.AppliedOn = DateTime.Now;

            var result = await _jobApplication.ApplyForJob(application);
            if (!result)
                return StatusCode(500, "Faild To submit Application");
            return Ok("Application Submit successfully");
        }
    }
}
