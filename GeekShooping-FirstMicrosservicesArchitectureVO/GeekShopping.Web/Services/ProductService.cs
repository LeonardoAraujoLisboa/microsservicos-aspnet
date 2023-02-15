using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";//vai la na controller do projeto back e ai pega esse api/v1 la na controller mesmo e o que vem depois da barra é o NOME DA CONTROLLER (product)

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> GetProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<ProductModel>();
            }
            else
            {
                throw new Exception("Something went wrong calling API");
            }
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<ProductModel>();
            }
            else
            {
                throw new Exception("Something went wrong calling API");
            }
        }

        public async Task<bool> DeleteProduct(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<bool>();
            }
            else
            {
                throw new Exception("Something went wrong calling API");
            }
        }
    }
}
