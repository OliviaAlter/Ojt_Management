using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;
        private readonly IMapper _mapper;

        public MajorController(IMajorService majorService, IMapper mapper)
        {
            _majorService = majorService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetMajorList()
        {
            try
            {
                var result = await _majorService.GetMajorList();
                if (result == null || !result.Any())
                    return NotFound("Empty major list");

                var response = _mapper.Map<IEnumerable<MajorDTO>>(result);
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting major data");
            }
        }

        [HttpGet("{name}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetMajorByName(string name)
        {
            try
            {
                if (name.Length == 0)
                    return BadRequest("Must have a valid input");

                var result = await _majorService.GetMajorByName(name);

                if (result == null)
                    return NotFound("Semester isn't in our database");

                // TODO: Check if there are any constraint with semester, if there is make sure to remove all of them
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting student data");
            }
        }

        [HttpGet("{name}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetMajorById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id must be positive");

                var result = await _majorService.GetMajorById(id);

                if (result == null)
                    return NotFound("Semester isn't in our database");

                // TODO: Check if there are any constraint with semester, if there is make sure to remove all of them
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting student data");
            }
        }

        [HttpGet("{name}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetMajorListByName(string name)
        {
            try
            {
                if (name.Length == 0)
                    return BadRequest("Name must be valid");

                var result = await _majorService.GetMajorListByName(name);
                if (result == null || !result.Any())
                    return NotFound($"No major found with the search value : {name}");

                var response = _mapper.Map<IEnumerable<MajorDTO>>(result);
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting major list");
            }
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMajor(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id must be positive");

                // TODO: Check if there are any constrains associated with the account
                var result = await _majorService.DeleteMajor(id);
                if (!result)
                    return NotFound("Major isn't in our database");
                return Ok("Account deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}