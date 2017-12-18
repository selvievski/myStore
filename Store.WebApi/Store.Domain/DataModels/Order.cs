using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Domain.DataModels
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
        public DateTime ModifiedOn { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
