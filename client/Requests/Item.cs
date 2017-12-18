using System;

namespace StoreApiClient.Requests
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public int NumberOfUnits { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
