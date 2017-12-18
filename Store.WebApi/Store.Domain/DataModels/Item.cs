using System;
using System.Collections.Generic;

namespace Store.Domain.DataModels
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public int NumberOfUnits { get; set; }
        public DateTime ModifiedOn { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
