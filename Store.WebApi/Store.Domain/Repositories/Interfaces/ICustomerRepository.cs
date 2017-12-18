using Store.Domain.DataModels;
using System.Collections.Generic;

namespace Store.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(int id);
        int Add(Customer entity);
        void Delete(int id);
        void Update(int id, Customer entity);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> Find(string text);
    }
}
