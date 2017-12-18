using Store.Domain.DataModels;
using System.Collections.Generic;

namespace Store.Domain.Repositories
{
    public interface IOrderRepository
    {
        Order Get(int id);
        int Add(Order entity);
        void Delete(int id);
        void Update(int id, Order entity);
        IEnumerable<Order> GetAll();
    }
}
