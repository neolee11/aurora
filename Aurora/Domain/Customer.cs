﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer : User
    {
        public int Id { get; set; }
        public Address ShippingAddress { get; set; }
        public string? Phone { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
