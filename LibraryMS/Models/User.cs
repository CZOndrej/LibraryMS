using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone{ get; set; }
        public int MyProperty { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }

    }
}
