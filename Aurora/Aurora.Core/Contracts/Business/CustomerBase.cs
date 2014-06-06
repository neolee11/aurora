using System;
using System.Collections.Generic;
using Aurora.Core.Models.UserAccountModels;

namespace Aurora.Core.Contracts.Business
{
    public abstract class CustomerBase : SystemUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address ShippingAddress { get; set; }
        public bool? IsStudent { get; set; }  //This is to test ? in EF Db creation
        public DateTime DateJoined { get; set; }
        public List<CreditCard> CreditCards { get; set; }
    }
}