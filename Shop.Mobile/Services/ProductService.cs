using System.Net.Http.Json;
using System.Text.Json;
using Shop.Mobile.Models;

namespace Shop.Mobile.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public ProductService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5129/api/v1/");

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>("products", _serializerOptions);
            return response ?? new List<Product>();
        }
    }
}
