using Store.Domain.DataModels;
using System.Collections.Generic;

namespace Store.Domain.Repositories
{
    public interface IItemRepository
    {
        Item Get(int id);
        int Add(Item entity);
        void Delete(int id);
        void Update(int id, Item entity);
        IEnumerable<Item> GetAll();
    }
}
