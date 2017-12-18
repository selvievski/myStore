using StoreApiClient.Helpers;
using StoreApiClient.Requests;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StoreApiClient
{
    class Program
    {
        static HttpClient client = new HttpClient();
        // Update port # in the following line.
        static string ApiAddress = "http://localhost:9865/";

        static void Main()
        {
            CustomerHelper.client = client;
            ItemHelper.client = client;
            OrderHelper.client = client;
            OrderItemHelper.client = client;
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(ApiAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                #region Customer
                Console.WriteLine($"==========================================");
                // Create a new customer
                Customer customer = new Customer
                {
                    Username = "filip.selvievski",
                    FirstName = "Filip",
                    LastName = "Selvievski",
                    Password = "Passw0rd",
                    Age = 28,
                    Gender = "male"
                };

                int customerId = await CustomerHelper.CreateCustomerAsync(customer);
                Console.WriteLine($"Customer created with id: {customerId}");

                // Get the Customer
                customer = await CustomerHelper.GetCustomerAsync(customerId);
                CustomerHelper.ShowCustomer(customer);

                //// Update the Customer
                Console.WriteLine("Updating customer age...");
                customer.Age = 80;
                await CustomerHelper.UpdateCustomerAsync(customer);

                //// Get the updated Customer
                customer = await CustomerHelper.GetCustomerAsync(customer.CustomerId);
                CustomerHelper.ShowCustomer(customer);

                #endregion

                #region Items
                Console.WriteLine($"==========================================");
                // Create a new Items
                Item item_1 = new Item
                {
                    Name = "Item 1",
                    Description = "Item Description 1",
                    Price = 100,
                    Location = "Germany",
                    NumberOfUnits = 1200
                };

                Item item_2 = new Item
                {
                    Name = "Item 2",
                    Description = "Item Description 2",
                    Price = 200,
                    Location = "Germany",
                    NumberOfUnits = 2200
                };

                int item_1_Id = await ItemHelper.CreateItemAsync(item_1);
                Console.WriteLine($"Item '1' created with id: {item_1_Id}");

                int item_2_Id = await ItemHelper.CreateItemAsync(item_2);
                Console.WriteLine($"Item '2' created with id: {item_2_Id}");

                // Get the Items
                item_1 = await ItemHelper.GetItemAsync(item_1_Id);
                ItemHelper.ShowItem(item_1);
                item_2 = await ItemHelper.GetItemAsync(item_2_Id);
                ItemHelper.ShowItem(item_2);

                //// Update the Items
                Console.WriteLine("Updating item '1' age...");
                item_1.NumberOfUnits = 1201;
                item_1.Price = 101;
                await ItemHelper.UpdateItemAsync(item_1);

                Console.WriteLine("Updating item '2' age...");
                item_2.NumberOfUnits = 2201;
                item_2.Price = 201;
                await ItemHelper.UpdateItemAsync(item_2);

                //// Get the updated Item

                item_1 = await ItemHelper.GetItemAsync(item_1.Id);
                ItemHelper.ShowItem(item_1);

                item_2 = await ItemHelper.GetItemAsync(item_2.Id);
                ItemHelper.ShowItem(item_2);

                #endregion

                #region Order
                Console.WriteLine($"==========================================");
                // Create a new Order
                Order order = new Order
                {
                    Name = "First Order",
                    Active = false,
                    CustomerId = customer.CustomerId
                };

                int orderId = await OrderHelper.CreateOrderAsync(order);
                Console.WriteLine($"Order created with id: {orderId}");

                // Get the Order
                order = await OrderHelper.GetOrderAsync(orderId);
                OrderHelper.ShowOrder(order);

                //// Update the Order
                Console.WriteLine("Updating Order Active parameter...");
                order.Active = true;
                await OrderHelper.UpdateOrderAsync(order);

                //// Get the updated Order
                order = await OrderHelper.GetOrderAsync(order.Id);
                OrderHelper.ShowOrder(order);

                #endregion

                #region OrderItem
                Console.WriteLine($"==========================================");
                // Create a new OrderItem
                OrderItem orderItem_1 = new OrderItem
                {
                    OrderId = order.Id,
                    ItemId = item_1.Id,
                    Quantity = 1
                };

                OrderItem orderItem_2 = new OrderItem
                {
                    OrderId = order.Id,
                    ItemId = item_2.Id,
                    Quantity = 2
                };

                int orderItemId_1 = await OrderItemHelper.CreateOrderItemAsync(orderItem_1);
                Console.WriteLine($"OrderItem '1' created with id: {orderItemId_1}");

                int orderItemId_2 = await OrderItemHelper.CreateOrderItemAsync(orderItem_2);
                Console.WriteLine($"OrderItem '2' created with id: {orderItemId_2}");

                // Get the OrderItem
                orderItem_1 = await OrderItemHelper.GetOrderItemAsync(orderItemId_1);
                OrderItemHelper.ShowOrderItem(orderItem_1);

                orderItem_2 = await OrderItemHelper.GetOrderItemAsync(orderItemId_2);
                OrderItemHelper.ShowOrderItem(orderItem_2);

                //// Update the OrderItem
                Console.WriteLine("Updating OrderItem '1' quantity...");
                orderItem_1.Quantity = 10;
                await OrderItemHelper.UpdateOrderItemAsync(orderItem_1);

                Console.WriteLine("Updating OrderItem '2' quantity...");
                orderItem_2.Quantity = 20;
                await OrderItemHelper.UpdateOrderItemAsync(orderItem_2);

                //// Get the updated OrderItem
                orderItem_1 = await OrderItemHelper.GetOrderItemAsync(orderItem_1.Id);
                OrderItemHelper.ShowOrderItem(orderItem_1);

                orderItem_2 = await OrderItemHelper.GetOrderItemAsync(orderItem_2.Id);
                OrderItemHelper.ShowOrderItem(orderItem_2);

                #endregion

                #region Delete data
                Console.WriteLine($"==========================================");
                var statusCode = await OrderItemHelper.DeleteOrderItemAsync(order.Id);
                Console.WriteLine($"Clear Order/ Remove all order items (HTTP Status = {(int)statusCode})");

                statusCode = await OrderHelper.DeleteOrderAsync(order.Id);
                Console.WriteLine($"Order Deleted (HTTP Status = {(int)statusCode})");

                statusCode = await ItemHelper.DeleteItemAsync(item_1.Id);
                Console.WriteLine($"Item '1' Deleted (HTTP Status = {(int)statusCode})");

                statusCode = await ItemHelper.DeleteItemAsync(item_2.Id);
                Console.WriteLine($"Item '2' Deleted (HTTP Status = {(int)statusCode})");

                statusCode = await CustomerHelper.DeleteCustomerAsync(customer.CustomerId);
                Console.WriteLine($"Customer Deleted (HTTP Status = {(int)statusCode})");

                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}