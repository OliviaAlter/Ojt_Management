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
    public class SemesterCompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISemesterCompanyService _semesterCompanyService;

        public SemesterCompanyController(IMapper mapper, ISemesterCompanyService semesterCompanyService)
        {
            _mapper = mapper;
            _semesterCompanyService = semesterCompanyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSemesterCompanyList()
        {
            try
            {
                var result = await _semesterCompanyService.GetSemesterCompanyList();
                if (result == null || !result.Any())
                    return NotFound("Empty semester company list");

                var response = _mapper.Map<IEnumerable<SemesterCompany>>(result);
                return Ok(response);
            }

            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Getting semester company list is unavailable"
                });     
            }
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSemesterCompanyById(int id)
        {
            try
            {
                var result = await _semesterCompanyService.GetSemesterCompanyById(id);
                if (result == null)
                    return NotFound("No semester company found");

                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Getting semester company list by id is unavailable"
                });     
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetSemesterCompanyListByName(string name)
        {
            try
            {
                var result = await _semesterCompanyService.GetSemesterCompanyListByName(name);
                if (result == null || !result.Any())
                    return NotFound("No semester company found");

                var response = _mapper.Map<IEnumerable<SemesterCompany>>(result);
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Getting semester company list by name is unavailable"
                });     
            }
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSemesterCompanyListBySemesterId(int id)
        {
            try
            {
                var result = await _semesterCompanyService.GetSemesterCompanyListBySemesterId(id);
                if (result == null || !result.Any())
                    return NotFound("No semester company found");

                var response = _mapper.Map<IEnumerable<SemesterCompany>>(result);
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Getting semester company list by semester is unavailable"
                });     
            }
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin, Company")]
        public async Task<IActionResult> RegisterSemesterCompany(AddSemesterCompanyDTO semesterCompany)
        {
            try
            {
                var newSemesterCompany = new SemesterCompany
                {
                    SemesterId = semesterCompany.SemesterId
                };
                var result = await _semesterCompanyService.AddSemesterCompany(newSemesterCompany);
                var response = _mapper.Map<SemesterCompanyDTO>(result);
                return StatusCode(201, response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Registering new semester company is unavailable"
                });
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin, Company")]

        public async Task<IActionResult> DeleteSemesterCompany(int id)
        {
            try
            {
                // TODO: Check if there are any constrains associated with the account
                var result = await _semesterCompanyService.DeleteSemesterCompany(id);
                if (!result)
                    return NotFound("Semester company isn't in our database");
                return Ok("Semester company deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Deleting semester company is unavailable"
                });            
            }
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin, Company")]
        public async Task<IActionResult> UpdateSemesterCompany(int id, [FromBody] SemesterCompanyDTO semesterCompany)
        {
            try
            {
                var result = await _semesterCompanyService.UpdateSemesterCompany(id, semesterCompany);

                if (result == null)
                    return NotFound("Updated failed");

                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Updating new semester company is unavailable"
                });
            }
        }
    }
}