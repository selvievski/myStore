using Store.Domain.DataModels;
using Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace Store.WebApi.Extensions
{
    static class ExtensionMethods
    {
        #region Customer

        public static CustomerDto ToDto(this Customer value)
        {
            CustomerDto dto = new CustomerDto();
            dto.CustomerId = value.CustomerId;
            dto.Username = value.Username;
            dto.FirstName = value.FirstName;
            dto.LastName = value.LastName;
            dto.Password = value.Password;
            dto.Age = value.Age;
            dto.Gender = value.Gender;
            dto.ModifiedOn = value.ModifiedOn;
            if (value.Orders != null && value.Orders.Count() > 0)
                dto.Orders = value.Orders.ToDtos().ToList();
            return dto;
        }

        public static Customer ToEntity(this CustomerDto value, Customer entity = null)
        {
            if (entity == null) entity = new Customer();
            entity.Username = value.Username;
            entity.FirstName = value.FirstName;
            entity.LastName = value.LastName;
            entity.Password = value.Password;
            entity.Age = value.Age;
            entity.Gender = value.Gender;
            entity.ModifiedOn = value.ModifiedOn;
            return entity;
        }

        public static IEnumerable<CustomerDto> ToDtos(this IEnumerable<Customer> value)
        {
            IEnumerable<CustomerDto> dtos = value.Select(x => x.ToDto());
            return dtos;
        }

        #endregion

        #region Item

        public static ItemDto ToDto(this Item value)
        {
            ItemDto dto = new ItemDto();
            dto.Id = value.ItemId;
            dto.Name = value.Name;
            dto.Description = value.Description;
            dto.Price = value.Price;
            dto.Location = value.Location;
            dto.NumberOfUnits = value.NumberOfUnits;
            dto.ModifiedOn = value.ModifiedOn;
            if (value.OrderItems != null && value.OrderItems.Count() > 0)
                dto.OrderItems = value.OrderItems.ToDtos().ToList();
            return dto;
        }

        public static Item ToEntity(this ItemDto value, Item entity = null)
        {
            if (entity == null) entity = new Item();
            entity.Name = value.Name;
            entity.Description = value.Description;
            entity.Price = value.Price;
            entity.Location = value.Location;
            entity.NumberOfUnits = value.NumberOfUnits;
            entity.ModifiedOn = value.ModifiedOn;
            return entity;
        }

        public static IEnumerable<ItemDto> ToDtos(this IEnumerable<Item> value)
        {
            IEnumerable<ItemDto> dtos = value.Select(x => x.ToDto());
            return dtos;
        }

        #endregion

        #region Order

        public static OrderDto ToDto(this Order value)
        {
            OrderDto dto = new OrderDto();
            dto.Id = value.OrderId;
            dto.Name = value.Name;
            dto.CreatedOn = value.CreatedOn;
            dto.Active = value.Active;
            dto.ModifiedOn = value.ModifiedOn;
            dto.CustomerId = value.CustomerId;
            if (value.OrderItems != null && value.OrderItems.Count() > 0)
                dto.OrderItems = value.OrderItems.ToDtos().ToList();
            return dto;
        }

        public static Order ToEntity(this OrderDto value, Order entity = null)
        {
            if (entity == null) entity = new Order();
            entity.Name = value.Name;
            entity.CreatedOn = value.CreatedOn;
            entity.Active = value.Active;
            entity.ModifiedOn = value.ModifiedOn;
            entity.CustomerId = value.CustomerId;
            return entity;
        }

        public static IEnumerable<OrderDto> ToDtos(this IEnumerable<Order> value)
        {
            IEnumerable<OrderDto> dtos = value.Select(x => x.ToDto());
            return dtos;
        }

        #endregion

        #region OrderItem

        public static OrderItemDto ToDto(this OrderItem value)
        {
            OrderItemDto dto = new OrderItemDto();
            dto.Id = value.OrderItemId;
            dto.Quantity = value.Quantity;
            dto.ModifiedOn = value.ModifiedOn;
            dto.OrderId = value.OrderId;
            dto.ItemId = value.ItemId;
            return dto;
        }

        public static OrderItem ToEntity(this OrderItemDto value, OrderItem entity = null)
        {
            if (entity == null) entity = new OrderItem();
            entity.Quantity = value.Quantity;
            entity.ModifiedOn = value.ModifiedOn;
            entity.OrderId = value.OrderId;
            entity.ItemId = value.ItemId;
            return entity;
        }

        public static IEnumerable<OrderItemDto> ToDtos(this IEnumerable<OrderItem> value)
        {
            IEnumerable<OrderItemDto> dtos = value.Select(x => x.ToDto());
            return dtos;
        }

        #endregion
    }
}