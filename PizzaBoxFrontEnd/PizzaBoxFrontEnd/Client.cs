using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaBoxFrontEnd.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace PizzaBoxFrontEnd
{
    public class Client
    {
        string url = "https://localhost:44303/api/";
        public IEnumerable<Customer> GetAllCustomers()
        {
            
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url + "Customer");
            var response = client.GetAsync("");
            response.Wait();


            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Customer[]>();
                readTask.Wait();

                var customers = readTask.Result;
                return customers;
            }
            return null;
        }

        public Customer GetCustomerByName(string name)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url + "Customer/name/" + name);
            var response = client.GetAsync("");
            response.Wait();

            var result = response.Result;// this holds the output

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Customer>();
                readTask.Wait();

                var Customer = readTask.Result;
                return Customer;
            }
            else
                return null;
        }


        public async void AddCustomer(Customer Customer)
        {
            var json = JsonConvert.SerializeObject(Customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync(url + "Customer", data);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        public async void AddOrder(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync(url + "Order", data);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        public async void AddOrderPizza(OrderPizza orderPizza)
        {
            var json = JsonConvert.SerializeObject(orderPizza);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync(url + "OrderPizza", data);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        public async void AddPizza(Pizza pizza)
        {
            var json = JsonConvert.SerializeObject(pizza);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync(url + "Pizza", data);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        public async void AddPizzaTopping(PizzaTopping pizzatopping)
        {
            var json = JsonConvert.SerializeObject(pizzatopping);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync(url + "PizzaTopping", data);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url + "Order/Customerid/" + id);
            var response = client.GetAsync("");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Order[]>();
                readTask.Wait();

                var orders = readTask.Result;
                return orders;
            }
            return null;
        }
        public IEnumerable<Order> GetOrdersByStoreId(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url + "Order/Storeid/" + id);
            var response = client.GetAsync("");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Order[]>();
                readTask.Wait();

                var orders = readTask.Result;
                return orders;
            }
            return null;
        }

        public IEnumerable<OrderPizza> GetOrderPizzaByOrderId(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url + "OrderPizza/" + id);
            var response = client.GetAsync("");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<OrderPizza[]>();
                readTask.Wait();

                var orders = readTask.Result;
                return orders;
            }
            return null;
        }

        public Order GetOrderById(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url + "Order/" + id);
            var response = client.GetAsync("");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Order>();
                readTask.Wait();

                var order = readTask.Result;
                return order;
            }
            return null;
        }

        public Order GetRecentlyAddedOrder()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url + "Order/");
            var response = client.GetAsync("");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Order>();
                readTask.Wait();

                var order = readTask.Result;
                return order;
            }
            return null;
        }

        public Pizza GetRecentlyAddedPizza()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url + "Pizza/GetRecent");
            var response = client.GetAsync("");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Pizza>();
                readTask.Wait();

                var pizza = readTask.Result;
                return pizza;
            }
            return null;
        }

        public async void DeleteOrderPizza(int id)
        {
            using var Client = new HttpClient();
            Client.BaseAddress = new Uri(url + "OrderPizza/" + id);
            var response = await Client.DeleteAsync("");
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

    }
}
