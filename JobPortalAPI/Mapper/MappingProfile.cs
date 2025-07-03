using AutoMapper;
using JobPortalAPI.Models;
using JobPortalAPI.Models.DTOs;

namespace JobPortalAPI.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Map between Job and JobDto
            CreateMap<Job, JobDto>().ReverseMap();

            // Map between Job and JobCreateDto (for POST requests)
            CreateMap<Job, JobCreateDto>().ReverseMap();

            CreateMap<JobApplicationCreateDto, JobApplication>().ReverseMap();
        }

    }
}
