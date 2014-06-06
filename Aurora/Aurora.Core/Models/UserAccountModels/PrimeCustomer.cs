using System;
using Aurora.Core.Contracts.Business;

namespace Aurora.Core.Models.UserAccountModels
{
    public class PrimeCustomer : CustomerBase
    {
        public DateTime PrimeJoinDate { get; set; }
    }
}