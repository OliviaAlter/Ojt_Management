using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting semester company data");
            }
        }
    }
}