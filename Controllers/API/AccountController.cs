using System.Collections.Generic;
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

namespace OJTManagementAPI.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;

        public AccountController(IAccountService accountService, IMapper mapper, ITokenServices tokenServices)
        {
            _accountService = accountService;
            _mapper = mapper;
            _tokenServices = tokenServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAccountList()
        {
            try
            {
                var result = await _accountService.GetAccountList();
                if (result == null || !result.Any())
                    return NotFound("No account found in database");

                var response = _mapper.Map<IEnumerable<AccountDTO>>(result);

                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Account data is unable to load"
                });
            }
        }

        [HttpGet("{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAccountListContainingName(string name)
        {
            try
            {
                var result = await _accountService.GetAccountListByName(name);
                if (result == null || !result.Any())
                    return NotFound($"No company found in database with the search value : {name}");

                var response = _mapper.Map<IEnumerable<AccountDTO>>(result);
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Account list is unable to load"
                });
            }
        }

        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAccount(RegisterAccountDTO registerAccountDto)
        {
            try
            {
                var newAccount = new Account
                {
                    Username = registerAccountDto.Username,
                    Password = registerAccountDto.Password,
                    RoleId = (int)RoleEnum.Student
                };
                var result = await _accountService.AddAccount(newAccount);
                var response = _mapper.Map<AccountDTO>(result);
                return StatusCode(201, response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Register account is unavailable"
                });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAccount([FromBody] LoginAccountDTO loginAccountDto)
        {
            var newLoginAttempt = new Account
            {
                Email = loginAccountDto.Email,
                Password = loginAccountDto.Password
            };

            var loginAccount = await _accountService.GetAccount(newLoginAttempt);

            if (loginAccount == null)
                return Unauthorized(new ApiResponseMessage
                {
                    StatusCode = 401,
                    IsSuccess = false,
                    Message = "Invalid username or password"
                });

            var roleName = new Role
            {
                RoleName = loginAccount.Roles.RoleName
            };

            var finalizeLogin = new Account
            {
                Email = loginAccountDto.Email,
                Password = loginAccountDto.Password,
                Roles = roleName
            };

            return Ok(new ApiResponseMessage
            {
                StatusCode = 200,
                IsSuccess = true,
                Message = "Login successful",
                Data = _tokenServices.CreateToken(finalizeLogin)
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAccount(int id, Account account)
        {
            try
            {
                if (id != account.AccountId)
                    return BadRequest();

                var result = await _accountService.UpdateAccount(account);
                if (result == null)
                    return NotFound("Updated failed");
                return Ok("Account updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ApiResponseMessage
                {
                    StatusCode = 503,
                    IsSuccess = false,
                    Message = "Updating account is unavailable"
                });
            }
        }
    }
}