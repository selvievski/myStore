using Store.Domain.DataModels;
using Store.Domain.Repositories;
using System.Collections.Generic;

namespace Store.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;            
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer Get(int Id)
        {
            return _customerRepository.Get(Id);
        }

        public int Add(Customer entity)
        {
           return _customerRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }

        public void Update(int id, Customer entity)
        {
            _customerRepository.Update(id, entity);
        }
    }
}
