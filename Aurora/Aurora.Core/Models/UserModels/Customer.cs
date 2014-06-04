using System;
using System.Collections.Generic;
using Aurora.Core.Contracts.UserInfo;

namespace Aurora.Core.Models.UserModels
{
    public class Customer : User
    {
        public int Id { get; set; }
        public Address ShippingAddress { get; set; }
        public bool? IsMarried { get; set; } //This is to test ? in EF Db creation
        public DateTime DateJoined { get; set; }

        public List<CreditCard> CreditCards { get; set; }
    }
}
