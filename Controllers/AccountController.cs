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
using OJTManagementAPI.Enums;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;

        public AccountController(IAccountService accountService, IMapper mapper, ITokenServices tokenServices, IRoleService roleService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _tokenServices = tokenServices;
            _roleService = roleService;
        }

        [HttpGet]
        [AllowAnonymous]
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
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting account data");
            }
        }

        [HttpGet("{name}")]
        [Authorize("Admin")]
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
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting account data");
            }
        }

        [HttpPost("register")]
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
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting account data");
            }
        }
        

        [HttpPost("login")]
        public async Task<IActionResult> LoginAccount([FromBody] LoginAccountDTO loginAccountDto)
        {
                var newLoginAttempt = new Account
                {
                    Email = loginAccountDto.Email,
                    Password = loginAccountDto.Password,
                };

                var loginAccount = await _accountService.GetAccount(newLoginAttempt);

                if (loginAccount == null)
                    return Unauthorized(new ApiResponseMessage
                    {
                        IsSuccess = false,
                        Message = "Invalid username or password"
                    });

                var roleLoginAttempt = new Role
                {
                    RoleId = loginAccount.RoleId,
                };

                var roleAccount = await _roleService.GetRole(roleLoginAttempt);

                var roleLoginDetail = new Role
                {
                    RoleName = roleAccount.RoleName
                };
                
                var finalizeLogin = new Account
                {
                    Email = loginAccountDto.Email,
                    Password = loginAccountDto.Password,
                    Roles = roleLoginDetail
                };

                return Ok(new ApiResponseMessage
                {
                    IsSuccess = true,
                    Message = "Login successful",
                    Data = _tokenServices.CreateToken(finalizeLogin)
                });
        }

        [HttpPut("{id}")]
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
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}