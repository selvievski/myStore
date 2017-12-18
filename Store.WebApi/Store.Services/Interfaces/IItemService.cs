using Store.Domain.DataModels;
using System.Collections.Generic;

namespace Store.Services
{
    public interface IItemService
    {
        /// <summary>
        /// Get All Items
        /// </summary>
        /// <returns>List of Items</returns>
        IEnumerable<Item> GetAll();

        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Item object</returns>
        Item Get(int Id);

        /// <summary>
        /// Add new Item
        /// </summary>
        /// <param name="entity"></param>
        int Add(Item entity);

        /// <summary>
        /// Delete Item by Id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Update Item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        void Update(int id, Item entity);
    }
}
