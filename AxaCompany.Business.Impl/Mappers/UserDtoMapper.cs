using System;
using System.Collections.Generic;
using System.Text;
using AxaCompany.Business.Contracts.Dtos;
using AxaCompany.Business.Contracts.Dtos.Enum;
using AxaCompany.DataAccess.Contracts.Models;

namespace AxaCompany.Business.Impl.Mappers
{
    public static class UserDtoMapper
    {
        public static UserDto Map(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Mail = user.Mail,
                Name = user.Name,
                Role = (Role)(user.Role)
            };
        }

    }
}
