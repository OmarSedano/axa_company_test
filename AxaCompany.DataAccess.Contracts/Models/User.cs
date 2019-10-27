using System;
using System.Collections.Generic;
using AxaCompany.DataAccess.Contracts.Models.Enum;
using Newtonsoft.Json;

namespace AxaCompany.DataAccess.Contracts.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Mail { get; set; }
        [JsonProperty(PropertyName = "role")]
        public Role Role { get; set; }
        ////TODO: convert string tu enum
    }

    public class UsersData
    {
        [JsonProperty(PropertyName = "clients")]
        public IEnumerable<User> Users { get; set; }
    }

}
