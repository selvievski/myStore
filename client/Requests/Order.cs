using System;
using System.Collections.Generic;

namespace StoreApiClient.Requests
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CustomerId { get; set; }
    }
}
