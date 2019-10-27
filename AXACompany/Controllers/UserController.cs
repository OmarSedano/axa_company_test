using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxaCompany.Business.Contracts.Dtos;
using AxaCompany.Business.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AXACompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid userId)
        {
            return await _userService.GetUserById(userId).ConfigureAwait(false);
        }

        [HttpGet("policy/{id:guid}")]
        public async Task<ActionResult<UserDto>> GetUserByPolicy(Guid policyId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<UserDto>> GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }


        [HttpGet("{userName}/policies")]
        public async Task<ActionResult<IEnumerable<PolicyDto>>> GetPolicies(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
