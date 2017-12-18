using Store.Domain.DataModels;
using Store.Domain.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Domain.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrderItemRepository()
        {
            _dbContext = new StoreDbContext();
        }

        public OrderItem Get(int id)
        {
            return _dbContext.OrderItems.FirstOrDefault(x => x.OrderItemId == id);
        }

        public int Add(OrderItem entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            _dbContext.OrderItems.Add(entity);
            _dbContext.SaveChanges();
            return entity.OrderItemId;
        }

        public void Update(int id, OrderItem entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {            
            var entity = Get(id);
            _dbContext.OrderItems.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteAll(int id)
        {
            var ids = _dbContext.OrderItems.ToList().Where(x=>x.OrderId == id).Select(x => x.OrderItemId);
            foreach(int oiId in ids)
            {
                var entity = Get(oiId);
                _dbContext.OrderItems.Remove(entity);
            }
            _dbContext.SaveChanges();
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _dbContext.OrderItems;
        }
    }
}
