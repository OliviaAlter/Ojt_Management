using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService _applicationService;
        private readonly IMapper _mapper;

        public JobApplicationController(IJobApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetApplicationList()
        {
            try
            {
                var result = await _applicationService.GetJobApplicationList();
                if (result == null || !result.Any())
                    return NotFound("Empty application list");

                var response = _mapper.Map<IEnumerable<JobApplicationDTO>>(result);
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting application data");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            try
            {
                var result = await _applicationService.GetJobApplicationById(id);
                if (result == null)
                    return NotFound("No application found");

                return Ok(result);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting application data");
            }
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetJobApplicationByCompanyId(int companyId)
        {
            try
            {
                var result = await _applicationService.GetJobApplicationByCompanyId(companyId);
                if (result == null || !result.Any())
                    return NotFound("No application list found");

                var response = _mapper.Map<IEnumerable<JobApplicationDTO>>(result);
                return Ok(response);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting application data");
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetJobApplicationByStudentId(int studentId)
        {
            try
            {
                var result = await _applicationService.GetJobApplicationByStudentId(studentId);
                if (result == null || !result.Any())
                    return NotFound("No application list found");

                var response = _mapper.Map<IEnumerable<JobApplicationDTO>>(result);
                return Ok(response);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting application data");
            }
        }

        [HttpGet("{majorId}")]
        public async Task<IActionResult> GetApplicationByMajorId(int majorId)
        {
            try
            {
                var result = await _applicationService.GetJobApplicationByMajorId(majorId);
                if (result == null || !result.Any())
                    return NotFound("No application list found");

                var response = _mapper.Map<IEnumerable<JobApplicationDTO>>(result);
                return Ok(response);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting application data");
            }
        }


        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateJobApplication(int id, JobApplication jobApplication)
        {
            try
            {
                if (id != jobApplication.JobApplicationId)
                    return BadRequest();

                var result = await _applicationService.UpdateApplication(jobApplication);
                if (result != null)
                    return NotFound("Update failed successfully");
                return Ok("Application updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id must be positive");

                var result = await _applicationService.DeleteApplication(id);
                if (!result)
                    return NotFound($"Application with id : {id} isn't in our database");
                // TODO: Check if there are any constraint with student or company, if there is make sure to remove all of them
                return Ok("Application deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}