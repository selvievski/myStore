using StoreApiClient.Requests;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreApiClient.Helpers
{
    public class OrderHelper        
    {
        public static HttpClient client;
        public static string requestUri = "api/order";

        public static void ShowOrder(Order order)
        {
            Console.WriteLine(
                string.Format("Name: {0}, Active: {1}, CreatedOn: {2}, ModifiedOn: {3}, CustomerId: {4}",
                order.Name,
                order.Active,
                order.CreatedOn,
                order.ModifiedOn,
                order.CustomerId
                ));
        }

        public static async Task<int> CreateOrderAsync(Order order)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                requestUri, order);
            response.EnsureSuccessStatusCode();

            order = response.Content.ReadAsAsync<Order>().Result;
            // return URI of the created resource.
            return order.Id;
        }

        public static async Task<Order> GetOrderAsync(int id)
        {
            Order order = null;
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}",requestUri,id));
            if (response.IsSuccessStatusCode)
            {
                order = await response.Content.ReadAsAsync<Order>();
            }
            return order;
        }

        public static async Task<Order> UpdateOrderAsync(Order order)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
               string.Format("{0}/{1}", requestUri, order.Id), order);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated Order from the response body.
            order = await response.Content.ReadAsAsync<Order>();
            return order;
        }

        public static async Task<HttpStatusCode> DeleteOrderAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                string.Format("{0}/{1}", requestUri, id));
            return response.StatusCode;
        }
    }
}
