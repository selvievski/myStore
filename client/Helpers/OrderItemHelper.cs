using StoreApiClient.Requests;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreApiClient.Helpers
{
    public class OrderItemHelper        
    {
        public static HttpClient client;
        public static string requestUri = "api/orderitem";

        public static void ShowOrderItem(OrderItem orderItem)
        {
            Console.WriteLine(
                string.Format("ItemId: {0}, OrderId: {1}, Quantity: {2}, ModifiedOn: {3}",
                orderItem.ItemId,
                orderItem.OrderId,
                orderItem.Quantity,
                orderItem.ModifiedOn
                ));
        }

        public static async Task<int> CreateOrderItemAsync(OrderItem orderItem)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                requestUri, orderItem);
            response.EnsureSuccessStatusCode();

            orderItem = response.Content.ReadAsAsync<OrderItem>().Result;
            // return URI of the created resource.
            return orderItem.Id;
        }

        public static async Task<OrderItem> GetOrderItemAsync(int id)
        {
            OrderItem orderItem = null;
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}",requestUri,id));
            if (response.IsSuccessStatusCode)
            {
                orderItem = await response.Content.ReadAsAsync<OrderItem>();
            }
            return orderItem;
        }

        public static async Task<OrderItem> UpdateOrderItemAsync(OrderItem orderItem)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
               string.Format("{0}/{1}", requestUri, orderItem.Id), orderItem);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated OrderItem from the response body.
            orderItem = await response.Content.ReadAsAsync<OrderItem>();
            return orderItem;
        }

        public static async Task<HttpStatusCode> DeleteOrderItemAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                string.Format("{0}/{1}", requestUri, id));
            return response.StatusCode;
        }
    }
}
