using System;
using System.Collections.Generic;
using Aurora.Core.Models.UserAccountModels;

namespace Aurora.Core.Contracts.Business
{
    public abstract class CustomerBase : SystemUser
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Address ShippingAddress { get; set; }
        bool? IsStudent { get; set; }  //This is to test ? in EF Db creation
        DateTime DateJoined { get; set; }

        List<CreditCard> CreditCards { get; set; }
    }
}