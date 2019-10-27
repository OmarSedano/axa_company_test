using System;
using System.Collections.Generic;
using System.Text;

namespace AxaCompany.Business.Contracts.Dtos
{
    public class PolicyDto
    {
        public Guid Id { get; set; }
        public float AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime InceptionDate { get; set; }
        public DateTime InstallmentPayment { get; set; }
        public Guid ClientId { get; set; }
    }
}
