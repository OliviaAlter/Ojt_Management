﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;
using OJTManagementAPI.Enums;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> GetStudentList()
        {
            try
            {
                var result = await _studentService.GetStudentList();
                if (result == null || !result.Any())
                    return NotFound("Empty Student List");

                var response = _mapper.Map<IEnumerable<StudentDTO>>(result);
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting student data");
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetStudentListByName(string name)
        {
            try
            {
                var result = await _studentService.GetStudentListByName(name);
                if (result == null || !result.Any())
                    return NotFound($"No student list containing the search input : {name}");

                var response = _mapper.Map<IEnumerable<StudentDTO>>(result);
                return Ok(response);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting student data");
            }
        }

        [HttpGet("{semesterId:int}")]
        public async Task<IActionResult> GetStudentListBySemesterId(int semesterId)
        {
            try
            {
                var result = await _studentService.GetStudentListBySemesterId(semesterId);

                if (!result.Any())
                    return NotFound("Semester isn't in our database");

                // TODO: Check if there are any constraint with semester, if there is make sure to remove all of them
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting student data");
            }
        }

        [HttpGet("{companyId:int}")]
        public async Task<IActionResult> GetStudentListByCompanyId(int companyId)
        {
            try
            {
                var result = await _studentService.GetStudentListAppliedByCompanyId(companyId);

                if (!result.Any())
                    return NotFound("No student applied in this company");

                // TODO: Check if there are any constraint, if there is make sure to remove all of them
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting student data");
            }
        }

        [HttpGet("{majorId:int}")]
        public async Task<IActionResult> GetStudentListMajorId(int majorId)
        {
            try
            {
                var result = await _studentService.GetStudentListByMajorId(majorId);

                if (!result.Any())
                    return NotFound("No student in this major");

                // TODO: Check if there are any constraint, if there is make sure to remove all of them
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting student data");
            }
        }


        [HttpPut("{id:int}")]
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

        [HttpDelete("{studentId:int}")]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            try
            {
                var result = await _studentService.DeleteStudent(studentId);
                if (!result)
                    return NotFound("Student isn't in our database");
                return Ok("Student deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateStudent(RegisterStudentDTO registerStudentDto)
        {
            try
            {
                var registerAccountDto = new RegisterAccountDTO();

                var newStudent = new Account
                {
                    Username = registerAccountDto.Username,
                    Password = registerAccountDto.Password,
                    RoleId = (int)RoleEnum.Student
                };

                var newRegistration = new Student
                {
                    StudentCode = registerStudentDto.StudentCode,
                    SemesterId = registerStudentDto.SemesterId,
                    Name = registerStudentDto.Name,
                    Account = newStudent
                };
                var result = await _studentService.AddStudent(newRegistration);
                var response = _mapper.Map<StudentDTO>(result);
                return StatusCode(201, response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Error creating student");
            }
        }
    }
}