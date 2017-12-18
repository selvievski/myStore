using System;

namespace StoreApiClient.Requests
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
