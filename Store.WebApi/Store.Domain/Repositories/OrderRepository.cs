using Store.Domain.DataModels;
using Store.Domain.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Domain.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new StoreDbContext();
        }

        public Order Get(int id)
        {
            return _dbContext.Orders.FirstOrDefault(x => x.OrderId == id);
        }

        public int Add(Order entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
            return entity.OrderId;
        }

        public void Update(int id, Order entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            _dbContext.Orders.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders;
        }
    }
}
