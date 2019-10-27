using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxaCompany.Business.Contracts.Dtos;
using AxaCompany.Business.Contracts.Services;
using AxaCompany.Business.Impl.Mappers;
using AxaCompany.DataAccess.Contracts.Services;

namespace AxaCompany.Business.Impl.Services
{
    public class UserService:IUserService
    {

        private readonly IUserDataService _userDataService;

        public UserService(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task<UserDto> GetUserById(Guid userId)
        {
            return UserDtoMapper.Map(await _userDataService.GetUserById(userId).ConfigureAwait(false));
        }

        public async Task<UserDto> GetUserByPolicy(Guid policyId)
        {
            return UserDtoMapper.Map(await _userDataService.GetUserByPolicy(policyId).ConfigureAwait(false));
        }

        public async Task<UserDto> GetUserByName(string userName)
        {
            return UserDtoMapper.Map(await _userDataService.GetUserByName(userName).ConfigureAwait(false));
        }

        public async Task<IEnumerable<PolicyDto>> GetUserPolicies(string userName)
        {
            return (await _userDataService.GetUserPolicies(userName).ConfigureAwait(false)).Select(PolicyDtoMapper.Map);
        }
    }
}
