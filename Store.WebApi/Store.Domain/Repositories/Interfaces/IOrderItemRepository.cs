using Store.Domain.DataModels;
using System.Collections.Generic;

namespace Store.Domain.Repositories
{
    public interface IOrderItemRepository
    {
        OrderItem Get(int id);
        int Add(OrderItem entity);
        void Delete(int id);
        void DeleteAll(int id);
        void Update(int id, OrderItem entity);
        IEnumerable<OrderItem> GetAll();
    }
}
