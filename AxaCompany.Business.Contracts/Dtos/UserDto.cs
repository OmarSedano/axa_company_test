using System;
using System.Collections.Generic;
using System.Text;
using AxaCompany.Business.Contracts.Dtos.Enum;

namespace AxaCompany.Business.Contracts.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public Role Role { get; set; }
    }
}
