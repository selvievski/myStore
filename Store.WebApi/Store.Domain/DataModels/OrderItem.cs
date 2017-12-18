using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Domain.DataModels
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifiedOn { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
