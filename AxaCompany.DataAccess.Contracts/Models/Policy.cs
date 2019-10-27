using System;

namespace AxaCompany.DataAccess.Contracts.Models
{
    public class Policy
    {
        public Guid Id { get; set; }
        public float AmountInsured { get; set; }
        public string Email  { get; set; }
        public DateTime InceptionDate { get; set; }
        public DateTime InstallmentPayment { get; set; }
        public Guid ClientId { get; set; }
    }
}
