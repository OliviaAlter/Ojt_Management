using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.DTOs;
using OJTManagementAPI.Entities;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public JobController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobList()
        {
            try
            {
                var result = await _jobService.GetJobList();
                if (result == null || !result.Any())
                    return NotFound("No job found in database");

                var response = _mapper.Map<IEnumerable<JobDTO>>(result);

                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Job data is unable to load"
                });
            }
        }

        [HttpGet("{name}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetJobListContainName(string name)
        {
            try
            {
                var result = await _jobService.GetJobListContainName(name);
                if (result == null || !result.Any())
                    return NotFound($"No job data in database with the search value : {name}");

                var response = _mapper.Map<IEnumerable<JobDTO>>(result);
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Job list is unable to load"
                });
            }
        }

        [HttpPost("register")]
        [Authorize(Roles = "Company, Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostNewJob([FromForm] JobAddDTO newJob)
        {
            try
            {
                var job = new Job
                {
                    JobName = newJob.JobName,
                    JobDescription = newJob.JobDescription,
                    MajorId = newJob.MajorId,
                    CompanyId = newJob.CompanyId
                };
                var result = await _jobService.AddJob(job);
                return StatusCode(201, result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Creating new job is unavailable"
                });
            }
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Company, Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] JobUpdateDTO jobUpdate)
        {
            try
            {
                if (id != jobUpdate.JobId)
                    return NotFound("Job not found");
                // TODO : Check if job update
                var major = new Major
                {
                    MajorName = jobUpdate.Major.MajorName
                };

                var job = new Job
                {
                    JobName = jobUpdate.JobName,
                    JobDescription = jobUpdate.JobDescription,
                    Major = major
                };

                var result = await _jobService.UpdateJob(id, job);

                if (result == null)
                    return NotFound("Major not found");

                return Ok("Major updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Updating company is unavailable"
                });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetJobDetail(int id)
        {
            try
            {
                var jobIdCheck = await _jobService.GetJobById(id);

                if (jobIdCheck == null)
                    return NotFound("Job not found");

                var result = await _jobService.GetJobData(jobIdCheck);
                if (result == null)
                    return NotFound("No job found in database");

                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Company is unavailable"
                });
            }
        }
    }
}