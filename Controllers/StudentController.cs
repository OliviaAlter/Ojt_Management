using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _studentService.GetStudentList();
            if (result == null || !result.Any()) 
                return NotFound("Empty Student List");

            var response = _mapper.Map<IEnumerable<StudentDTO>>(result);
            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetStudentByName(string name)
        {
            var result = await _studentService.GetStudentListByName(name);
            if (result == null || !result.Any())
                return NotFound($"No student list containing the search input : {name}");

            var response = _mapper.Map<IEnumerable<StudentDTO>>(result);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            try
            {
                if (id != student.AccountId)
                    return BadRequest();

                var result = await _studentService.UpdateStudent(student);
                if (result != null)
                    return NotFound("Update failed successfully");
                return Ok("Account updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id must be positive");

                var result = await _studentService.DeleteStudent(id);
                if (!result)
                    return NotFound($"Student with id : {id} isn't in our database");
                return Ok("Student deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

    }
}