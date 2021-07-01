using Ciber.Data.Enititys;
using Ciber.ViewModels.Catalog.Orders;
using Ciber.ViewModels.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ciber.WebApp.Services
{
    public class OrderApiClient : IOrderApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public OrderApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<PagedResult<OrderViewModel>> GetOrderPaging(GetOrderPagingRequest request)
        {
            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
            var response = await client.GetAsync($"/api/order/paging-order?PageIndex={request.PageIndex}" +
                $"&PageSize={request.PageSize}&CategoryName={request.CategoryName}");

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PagedResult<OrderViewModel>>(body);
            return result;
        }

        public async Task<bool> CreateOrder(OrderCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
            var response = await client.PostAsync($"/api/order/create", httpContent);

            //var body = await response.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<OrderViewModel>(body);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Product>> GetListProduct(string token)
        {
            
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/order/list-source-prod");

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(body);
            return result;
        }
        public async Task<List<Customer>> GetListCustomer(string token)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/order/list-source-cus");

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Customer>>(body);
            return result;
        }
    }
}
