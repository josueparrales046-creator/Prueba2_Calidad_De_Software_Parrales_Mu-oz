using EjemploMVC.Models;
using Newtonsoft.Json;

namespace EjemploMVC.Services
{
    public class ProductService
    {
        private HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProducts()
        {
            var response = await _httpClient.GetStringAsync("https://fakestoreapi.com/products");
            var products = JsonConvert.DeserializeObject<List<Product>>(response);
            return products ?? new List<Product>();

        }
        
        public async Task<Product> GetProduct(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://fakestoreapi.com/products/{id}");
            var product = JsonConvert.DeserializeObject<Product>(response);
            return product ?? new Product();
        }
    }
}
