using Ciber.Data.Enititys;
using Ciber.ViewModels.Catalog.Orders;
using Ciber.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.WebApp.Services
{
    public interface IOrderApiClient
    {
        Task<PagedResult<OrderViewModel>> GetOrderPaging(GetOrderPagingRequest request);
        Task<bool> CreateOrder(OrderCreateRequest request);
        Task<List<Customer>> GetListCustomer(string token);
        Task<List<Product>> GetListProduct(string token);
    }
}
