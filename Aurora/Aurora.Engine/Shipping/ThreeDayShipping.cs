﻿using Aurora.Core.Contracts.Business;

namespace Aurora.Engine.Shipping
{
    public class ThreeDayShipping : IShippingMethod
    {
        private decimal _rate = 5.00m;

        public decimal CalculatePrice()
        {
            return _rate;
        }

        public string MethodName()
        {
            return "THREE DAY SHIPPING";
        }
    }

}