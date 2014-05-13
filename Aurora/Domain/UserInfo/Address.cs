using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserInfo
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string FullAddress 
        {
            get
            {
                return string.Format("{0}, {1}, {2}, {3}", Street, City, State, Zip);
            }
        }
    }
}
