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
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISemesterService _semesterService;

        public SemesterController(ISemesterService semesterService, IMapper mapper)
        {
            _semesterService = semesterService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSemesterList()
        {
            var result = await _semesterService.GetSemesterList();
            if (result == null || !result.Any())
                return NotFound("Empty Student List");

            var response = _mapper.Map<IEnumerable<SemesterDTO>>(result);
            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetSemesterByName(string name)
        {
            var result = await _semesterService.GetSemesterByName(name);
            if (result == null || !result.Any())
                return NotFound($"No student list containing the search input : {name}");

            var response = _mapper.Map<IEnumerable<SemesterDTO>>(result);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSemester(int id, Semester semester)
        {
            try
            {
                if (id != semester.SemesterId)
                    return BadRequest();

                var result = await _semesterService.UpdateSemester(semester);
                if (result != null)
                    return NotFound("Update failed successfully");
                return Ok("Semester updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSemester(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id must be positive");

                var result = await _semesterService.DeleteSemester(id);
                if (!result)
                    return NotFound($"Semester with id : {id} isn't in our database");
                // TODO: Check if there are any constraint with semester, if there is make sure to remove all of them
                return Ok("Semester deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
        
        [HttpGet("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetSemesterById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id must be positive");

                var result = await _semesterService.GetSemesterById(id);

                if (result == null)
                    return NotFound($"Semester with id : {id} isn't in our database");

                // TODO: Check if there are any constraint with semester, if there is make sure to remove all of them
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting student data");
            }
        }
    }
}