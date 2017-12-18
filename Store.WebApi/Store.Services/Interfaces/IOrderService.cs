using Store.Domain.DataModels;
using System.Collections.Generic;

namespace Store.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Get all Orders
        /// </summary>
        /// <returns>List of Orders</returns>
        IEnumerable<Order> GetAllOrders();

        /// <summary>
        /// Get Order by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Order object</returns>
        Order GetOrder(int Id);

        /// <summary>
        /// Add new Order
        /// </summary>
        /// <param name="entity"></param>
        int AddOrder(Order entity);

        /// <summary>
        /// Delete Order by Id
        /// </summary>
        /// <param name="id"></param>
        void DeleteOrder(int id);

        /// <summary>
        /// Update Order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        void UpdateOrder(int id, Order entity);

        /// <summary>
        /// Get All OrderItems
        /// </summary>
        /// <returns>List of OrderItems</returns>
        IEnumerable<OrderItem> GetAllOrdersItems();

        /// <summary>
        /// Get OrderItem by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>OrderItem object</returns>
        OrderItem GetOrderItem(int Id);

        /// <summary>
        /// Add new OrderItem
        /// </summary>
        /// <param name="entity"></param>
        int AddOrderItem(OrderItem entity);

        /// <summary>
        /// Delete OrderItem
        /// </summary>
        /// <param name="id"></param>
        void DeleteOrderItem(int id);

        /// <summary>
        /// Update OrderItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        void UpdateOrderItem(int id, OrderItem entity);

        /// <summary>
        /// Remove all Items in Order (Deletes OrderItems) by OrderId
        /// </summary>
        /// <param name="orderId"></param>
        void RemoveAllOrderItems(int orderId);
    }
}
