using Store.Domain.DataModels;
using System.Data.Entity;

namespace Store.Domain.ORM
{
    //public static class StoreDbContext
    //{
    //    public static List<Customer> Customers = new List<Customer>();
    //    public static List<Order> Orders = new List<Order>();
    //    public static List<OrderItem> OrderItems = new List<OrderItem>();
    //    public static List<Item> Items = new List<Item>();
    //}

    public class StoreDbContext : DbContext
    {
        public StoreDbContext() : base()
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
