using StoreApiClient.Requests;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreApiClient.Helpers
{
    public class ItemHelper        
    {
        public static HttpClient client;
        public static string requestUri = "api/item";

        public static void ShowItem(Item item)
        {
            Console.WriteLine(
                string.Format("Name: {0}, Description: {1}, Price: {2}, NumberOfUnits: {3}, Location: {4}, ModifiedOn: {5}",
                item.Name,
                item.Description,
                item.Price,
                item.NumberOfUnits,
                item.Location,
                item.ModifiedOn                
                ));
        }

        public static async Task<int> CreateItemAsync(Item item)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/item", item);
            response.EnsureSuccessStatusCode();

            item = response.Content.ReadAsAsync<Item>().Result;
            // return URI of the created resource.
            return item.Id;
        }

        public static async Task<Item> GetItemAsync(int id)
        {
            Item item = null;
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}",requestUri,id));
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<Item>();
            }
            return item;
        }

        public static async Task<Item> UpdateItemAsync(Item item)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
               string.Format("{0}/{1}", requestUri, item.Id), item);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated Item from the response body.
            item = await response.Content.ReadAsAsync<Item>();
            return item;
        }

        public static async Task<HttpStatusCode> DeleteItemAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                string.Format("{0}/{1}", requestUri, id));
            return response.StatusCode;
        }
    }
}
