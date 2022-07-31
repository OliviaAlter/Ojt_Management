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

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetMajorById(int id)
        {
            try
            {
                var result = await _majorService.GetMajorById(id);

                if (result == null)
                    return NotFound("Major isn't in our database");

                // TODO: Check if there are any constraint with semester, if there is make sure to remove all of them
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting student data");
            }
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMajorListByName(string name)
        {
            try
            {
                var result = await _majorService.GetMajorListByName(name);
                if (result == null || !result.Any())
                    return NotFound($"No major found with the search value : {name}");

                var response = _mapper.Map<IEnumerable<MajorDTO>>(result);

                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting major list");
            }
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMajor([FromForm] MajorAddDTO major)
        {
            try
            {
                var newMajor = new Major
                {
                    MajorName = major.MajorName
                };
                var result = await _majorService.AddMajor(newMajor);
                var response = _mapper.Map<MajorAddDTO>(result);
                return StatusCode(201, response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Adding major is unavailable"
                });
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMajor(int id)
        {
            try
            {
                // TODO: Check if there are any constrains associated with the account
                var result = await _majorService.DeleteMajor(id);
                if (!result)
                    return NotFound("Major isn't in our database");
                return Ok("Account deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Deleting major is unavailable"
                });
            }
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMajor(int id, [FromBody] MajorUpdateDTO major)
        {
            try
            {
                var updateMajor = new Major
                {
                    MajorName = major.MajorName
                };

                if (id != major.MajorId)
                    return NotFound("Major not found");

                var result = await _majorService.UpdateMajorById(id, updateMajor);

                if (result == null)
                    return NotFound("Major not found");

                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Updating major is unavailable"
                });
            }
        }
    }
}