using Store.Domain.DataModels;
using Store.Domain.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Domain.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly StoreDbContext _dbContext;
        public ItemRepository()
        {
            _dbContext = new StoreDbContext();
        }

        public Item Get(int id)
        {
            return _dbContext.Items.FirstOrDefault(x => x.ItemId == id);
        }

        public int Add(Item entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();
            return entity.ItemId;
        }

        public void Update(int id, Item entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            _dbContext.Items.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Item> GetAll()
        {
            return _dbContext.Items;
        }
    }
}
