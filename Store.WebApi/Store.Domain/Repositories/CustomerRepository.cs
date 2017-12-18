using Store.Domain.DataModels;
using Store.Domain.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly StoreDbContext _dbContext;

        public CustomerRepository()
        {
            _dbContext = new StoreDbContext();
        }

        public Customer Get(int id)
        {
            return _dbContext.Customers.FirstOrDefault(x => x.CustomerId == id);
        }

        public int Add(Customer entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            _dbContext.Customers.Add(entity);
            _dbContext.SaveChanges();
            return entity.CustomerId;
        }

        public void Update(int id,Customer entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            _dbContext.Customers.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public IEnumerable<Customer> Find(string text)
        {
            return _dbContext.Customers.Where(x => x.Username.StartsWith(text)).ToList();
        }
    }
}
