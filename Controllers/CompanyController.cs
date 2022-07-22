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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        //TODO : Put option failed

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompany()
        {
            try
            {
                var result = await _companyService.GetCompanyList();
                if (result == null || !result.Any())
                    return NotFound("No company found in database");

                var response = _mapper.Map<IEnumerable<CompanyDTO>>(result);

                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting company data");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyDTO company)
        {
            try
            {
                var newCompany = new Company
                {
                    CompanyName = company.CompanyName,
                    Description = company.Description,
                    Address = company.Address,
                    Email = company.Email
                };
                var result = await _companyService.AddCompany(newCompany);
                return StatusCode(201, result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting company data");
            }
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyListByName(string name)
        {
            try
            {
                var result = await _companyService.GetCompanyListByName(name);
                if (result == null || !result.Any())
                    return NotFound($"No companies found in database with the search value : {name}");

                var response = _mapper.Map<IEnumerable<CompanyListDTO>>(result);

                return Ok(response);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting company data");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyUpdateDTO company)
        {
            try
            {
                var result = await _companyService.UpdateCompany(id, company);

                if (result == null)
                    return NotFound("Company not found");
                
                return Ok("Company updated");
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            try
            {
                var result = await _companyService.GetCompanyById(id);
                if (result == null)
                    return NotFound("No company found in database");

                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting company data");
            }
        }
    }
}