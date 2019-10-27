using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AxaCompany.Business.Contracts.Dtos;

namespace AxaCompany.Business.Contracts.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(Guid userId);
        Task<UserDto> GetUserByPolicy(Guid policy);
        Task<UserDto> GetUserByName(string userName);
        Task<IEnumerable<PolicyDto>> GetUserPolicies(string userName);
    }
}
