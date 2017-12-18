using Store.Domain.DataModels;
using System.Collections.Generic;

namespace Store.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Retrive a customer by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Customer object</returns>
        Customer Get(int Id);

        /// <summary>
        /// Add new Customer
        /// </summary>
        /// <param name="entity"></param>
        int Add(Customer entity);

        /// <summary>
        /// Delete a Customer by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        void Update(int id, Customer entity);
    }
}
