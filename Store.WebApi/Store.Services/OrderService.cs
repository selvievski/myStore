using Store.Domain.DataModels;
using Store.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Store.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        #region Order

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrder(int Id)
        {
            return _orderRepository.Get(Id);
        }

        public int AddOrder(Order entity)
        {
            return _orderRepository.Add(entity);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }

        public void UpdateOrder(int id, Order entity)
        {
            _orderRepository.Update(id, entity);
        }

        #endregion

        #region OrderItems

        public IEnumerable<OrderItem> GetAllOrdersItems()
        {
            return _orderItemRepository.GetAll();
        }

        public OrderItem GetOrderItem(int Id)
        {
            return _orderItemRepository.Get(Id);
        }

        public int AddOrderItem(OrderItem entity)
        {
            return _orderItemRepository.Add(entity);
        }

        public void DeleteOrderItem(int id)
        {
            _orderItemRepository.Delete(id);
        }

        public void UpdateOrderItem(int id, OrderItem entity)
        {
            _orderItemRepository.Update(id, entity);
        }

        public void RemoveAllOrderItems(int orderId)
        {
            _orderItemRepository.DeleteAll(orderId);
        }

        #endregion 
    }
}
