using System;
using System.Collections.Generic;
using System.Text;
using AxaCompany.Business.Contracts.Dtos;
using AxaCompany.DataAccess.Contracts.Models;

namespace AxaCompany.Business.Impl.Mappers
{
    public static class PolicyDtoMapper
    {
        public static PolicyDto Map(Policy policy)
        {
            return new PolicyDto()
            {
                Id = policy.Id,
                AmountInsured = policy.AmountInsured,
                ClientId = policy.ClientId,
                Email = policy.Email,
                InceptionDate = policy.InceptionDate,
                InstallmentPayment = policy.InstallmentPayment
            };
        }
    }
}
