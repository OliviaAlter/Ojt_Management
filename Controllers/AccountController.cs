using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAccountList()
        {
            var result = await _accountService.GetAccountList();
            if (result == null || result.Count == 0) 
                return NotFound("No account found in database");

            var response = _mapper.Map<IEnumerable<AccountDTO>>(result);

            return Ok(response);
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAccountListContainingName(string name)
        {
            var result = await _accountService.GetAccountListByName(name);
            if (result == null || result.Count == 0) return NotFound($"No company found in database with the search value : {name}");

            var response = _mapper.Map<IEnumerable<AccountDTO>>(result);

            return Ok(response);
        }

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount(RegisterAccountDTO registerAccountDto)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var result = await _accountService.DeleteAccount(id);
                if (!result)
                    return NotFound("Account not found");
                return Ok("Account deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
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
