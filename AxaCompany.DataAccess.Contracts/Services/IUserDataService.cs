using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AxaCompany.DataAccess.Contracts.Models;

namespace AxaCompany.DataAccess.Contracts.Services
{
    public interface IUserDataService
    {
        Task<User> GetUserById(Guid userId);
        Task<User> GetUserByPolicy(Guid policy);
        Task<User> GetUserByName(string userName);
        Task<IEnumerable<Policy>> GetUserPolicies(string userName);
    }
}
