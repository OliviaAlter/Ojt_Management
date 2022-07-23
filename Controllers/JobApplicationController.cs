using System;
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
        private readonly ISemesterCompanyService _semesterCompanyService;
        private readonly IMapper _mapper;

        public JobApplicationController(IJobApplicationService applicationService, IMapper mapper, ISemesterCompanyService semesterCompanyService)
        {
            _applicationService = applicationService;
            _mapper = mapper;
            _semesterCompanyService = semesterCompanyService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Company")]
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

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin, Company")]
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

        [HttpGet("{companyId:int}")]
        [Authorize(Roles = "Admin")]
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

        [HttpGet("{studentId:int}")]
        [Authorize(Roles = "Admin, Company")]
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

        [HttpGet("{majorId:int}")]
        [Authorize(Roles = "Admin, Company")]
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

        [HttpPost("add")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> AddJobApplication(AddJobApplicationDTO jobApplicationDto)
        {
            try
            {
                var semesterCompanyCheck = await _semesterCompanyService
                    .GetSemesterCompanyByCompanyId(jobApplicationDto.Company.CompanyId);

                if (User.Identity == null)
                    return NotFound(new ApiResponseMessage
                        {
                            StatusCode = 404,
                            IsSuccess = false,
                            Message = "Account not found"
                        }
                    );

                var userId = User.Identity.Name;

                if (userId == null)
                    return NotFound(new ApiResponseMessage
                        {
                            StatusCode = 404,
                            IsSuccess = false,
                            Message = "Account ID not found"
                        }
                    );
                
                var accountInfo = new Account 
                { 
                    AccountId = Int32.Parse(userId)
                };

                if (semesterCompanyCheck == null)
                    return NotFound(new ApiResponseMessage
                    {
                        StatusCode = 404,
                        IsSuccess = false,
                        Message = "Semester company is not registered in this semester"
                    });                  
                
                var companyInfo = new Company
                {
                    CompanyId = jobApplicationDto.Company.CompanyId,
                    CompanyName = jobApplicationDto.Company.CompanyName
                };
                
                var studentInfo = new Student
                {
                    SemesterId = jobApplicationDto.Student.SemesterId,
                    StudentId = accountInfo.Student.StudentId,
                    AccountId = accountInfo.AccountId,
                };

                var newApplication = new JobApplication
                {
                    Company = companyInfo,
                    ApplicationStatus = 0,
                    Student = studentInfo
                };
                
                var result = await _applicationService.AddJobApplication(newApplication);
                var response = _mapper.Map<AddJobApplicationDTO>(result);
                return StatusCode(201, response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    "Adding new application is unavailable");
            }
        }


        [HttpPut("{id:int}")]
        [Authorize(Roles = "Student")]
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
        
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin, Company")]
        public async Task<IActionResult> StatusChangeJobApplication(int id, JobApplication jobApplication)
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

        [HttpDelete("{id:int}")]
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