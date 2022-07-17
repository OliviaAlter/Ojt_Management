using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompany()
        {
            var result = await _companyService.GetCompanyList();
            if (result == null || !result.Any())
                return NotFound("No company found in database");

            var response = _mapper.Map<IEnumerable<CompanyDTO>>(result);

            return Ok(response);
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyListByName(string name)
        {
            var result = await _companyService.GetCompanyListByName(name);
            if (result == null || !result.Any())
                return NotFound($"No companies found in database with the search value : {name}");

            var response = _mapper.Map<IEnumerable<CompanyDTO>>(result);

            return Ok(response);
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyByName(string name)
        {
            var result = await _companyService.GetCompanyByName(name);
            if (result == null)
                return NotFound($"No company found in database with the search value : {name}");

            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var result = await _companyService.GetCompanyById(id);
            if (result == null)
                return NotFound("No company found in database");

            return Ok(result);
        }
    }
}