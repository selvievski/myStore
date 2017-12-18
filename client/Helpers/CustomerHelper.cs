using StoreApiClient.Requests;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreApiClient.Helpers
{
    public class CustomerHelper        
    {
        public static HttpClient client;
        public static string requestUri = "api/customer";

        public static void ShowCustomer(Customer customer)
        {
            Console.WriteLine(
                string.Format("FirstName: {0}, LastName: {1}, Username: {2}, Password: {3}, Age: {4}, Gender: {5}",
                customer.FirstName,
                customer.LastName,
                customer.Username,
                customer.Password,
                customer.Age,
                customer.Gender
                ));
        }

        public static async Task<int> CreateCustomerAsync(Customer customer)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                requestUri, customer);
            response.EnsureSuccessStatusCode();

            customer = response.Content.ReadAsAsync<Customer>().Result;
            // return URI of the created resource.
            return customer.CustomerId;
        }

        public static async Task<Customer> GetCustomerAsync(int id)
        {
            Customer customer = null;
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}",requestUri,id));
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<Customer>();
            }
            return customer;
        }

        public static async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
               string.Format("{0}/{1}", requestUri, customer.CustomerId), customer);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated customer from the response body.
            customer = await response.Content.ReadAsAsync<Customer>();
            return customer;
        }

        public static async Task<HttpStatusCode> DeleteCustomerAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                string.Format("{0}/{1}", requestUri, id));
            return response.StatusCode;
        }
    }
}
