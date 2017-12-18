using System;
using System.Collections.Generic;

namespace Store.Domain.DataModels
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime ModifiedOn { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
