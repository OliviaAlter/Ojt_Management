using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.ServiceInterfaces;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Get all student")]
        public async Task<IActionResult> GetStudents(int? page, int? size)
        {
            var result = await _studentService.GetStudentList(page, size);
            if (result == null || result.Count == 0) return NotFound("Empty Student List");

            var response = _mapper.Map<IEnumerable<UserDTO>>(result);

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetStudentListBMajor(int majorId, int? page, int? size)
        {
            var result = await _studentService.GetStudentListByMajorId(majorId, page, size);
            if (result == null || result.Count == 0) return NotFound("Empty student list");
            
            var response = _mapper.Map<IEnumerable<UserDTO>>(result);

            return Ok(response);
        }



    }
}