﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PurchaseItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
