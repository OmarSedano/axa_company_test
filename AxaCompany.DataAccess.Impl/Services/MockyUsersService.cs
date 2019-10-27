using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxaCompany.DataAccess.Contracts.Models;
using AxaCompany.DataAccess.Contracts.Services;

namespace AxaCompany.DataAccess.Impl.Services
{
    public class MockyUsersService:IUserDataService
    {
        public async Task<User> GetUserById(Guid userId)
        {
            var usersProxy = new WebApiClient.WebApiClient("http://www.mocky.io/v2/5808862710000087232b75ac");
            var usersData =  await usersProxy.GetAsync<UsersData>();
            return usersData?.Users?.FirstOrDefault(u => u.Id == userId)??  new User();
        }

        public async Task<User> GetUserByPolicy(Guid policy)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Policy>> GetUserPolicies(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
