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

namespace OJTManagementAPI.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService _applicationService;
        private readonly IMapper _mapper;
        private readonly ISemesterCompanyService _semesterCompanyService;

        public JobApplicationController(IJobApplicationService applicationService, IMapper mapper,
            ISemesterCompanyService semesterCompanyService)
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
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Application list is unable to load"
                });
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
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Application data is unable to load"
                });
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
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Application data by company is unable to load"
                });
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
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Application data by student is failed to load"
                });
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
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Application data by major is unable to load"
                });
            }
        }

        [HttpPost("add")]
        [Authorize(Roles = "Student")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddJobApplication([FromForm] AddJobApplicationDTO jobApplicationDto)
        {
            try
            {
                var semesterCompanyCheck = await _semesterCompanyService
                    .GetSemesterCompanyByCompanyId(jobApplicationDto.Company.CompanyId);

                if (semesterCompanyCheck == null)
                    return NotFound(new ApiResponseMessage
                    {
                        StatusCode = 404,
                        IsSuccess = false,
                        Message = "Semester company is not registered in this semester"
                    });
                
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
                    AccountId = int.Parse(userId)
                };

                var companyInfo = new Company
                {
                    CompanyId = jobApplicationDto.Company.CompanyId,
                };

                var studentInfo = new Student
                {
                    SemesterId = jobApplicationDto.Student.SemesterId,
                    StudentId = accountInfo.Student.StudentId,
                    AccountId = accountInfo.AccountId,
                    MajorId = jobApplicationDto.Student.MajorId
                };

                var newApplication = new JobApplication
                {
                    Company = companyInfo,
                    ApplicationStatus = null,
                    Student = studentInfo,
                };

                try
                {
                    await _applicationService.AddJobApplication(newApplication);
                }
                catch
                {
                    return
                        StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                        {
                            StatusCode = 503,
                            IsSuccess = false,
                            Message = "Application failed to create"
                        });
                }
                
                return Ok(new ApiResponseMessage
                {
                    StatusCode = 201,
                    IsSuccess = false,
                    Message = "Application added successfully"
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Creating new application is unavailable"
                });
            }
        }


        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin, Company")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateJobApplication(int id, [FromBody] JobApplication jobApplication)
        {
            try
            {
                if (id != jobApplication.JobApplicationId)
                    return BadRequest();

                var updateJobApplication = new JobApplication
                {
                    ApplicationStatus = jobApplication.ApplicationStatus
                };

                var result = await _applicationService.UpdateApplication(id, updateJobApplication);
                if (result != null)
                    return NotFound("Update failed successfully");
                return Ok("Application updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Application failed to update"
                });
            }
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin, Company")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StatusChangeJobApplication(int id,
            [FromBody] JobApplication jobApplication)
        {
            try
            {
                var updateStatusJobApplication = new JobApplication
                {
                    ApplicationStatus = jobApplication.ApplicationStatus
                };

                if (id != jobApplication.JobApplicationId)
                    return BadRequest();

                var result = await _applicationService.UpdateApplicationStatus(id, updateStatusJobApplication);
                if (result != null)
                    return NotFound("Status failed successfully");
                return Ok("Application status updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Application status failed to update"
                });
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
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
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Error deleting application"
                });
            }
        }
    }
}