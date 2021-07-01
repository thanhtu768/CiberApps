using Ciber.BackendAPI.Controllers;
using Ciber.Data.EF;
using Ciber.Data.Enititys;
using Ciber.Services.Catalog.Orders;
using Ciber.Services.System.Logger;
using Ciber.ViewModels.Catalog.Orders;
using Ciber.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace web_api_tests
{
    public class OrderControllerTest
    {
        //arrange
        OrderController _controller;
        IManagerOrderService<OrderCreateRequest, OrderUpdateRequest, OrderViewModel, GetOrderPagingRequest> _service;
        public OrderControllerTest()
        {
            _service = new ManagerOrderServiceFake();
            _controller = new OrderController(_service, null);
        }
        [Fact]
        public void  Get_WhenCalled_ReturnOkResult()
        {
            //Act
            var okResult =   _controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnAllOrder() 
        {
            //Act
            var okResult = _controller.Get().Result as OkObjectResult;
            //Assert
            var list_item = Assert.IsType<List<OrderViewModel>>(okResult.Value);
            Assert.Equal(3, list_item.Count);
        }
    }
    public class ManagerOrderServiceFake : IManagerOrderService<OrderCreateRequest, OrderUpdateRequest, OrderViewModel, GetOrderPagingRequest>
    {
        private readonly List<OrderViewModel> _orderView;
        public ManagerOrderServiceFake()
        {
            _orderView = new List<OrderViewModel>()
            {
                new OrderViewModel() {ID = 1, CustomerID = 1, ProductID = 1, Amount = 2, OrderDate = DateTime.Now },
                new OrderViewModel() { ID = 2, CustomerID = 1, ProductID = 2, Amount = 32, OrderDate = DateTime.Now },
                new OrderViewModel() { ID = 3, CustomerID = 1, ProductID = 3, Amount = 11, OrderDate = DateTime.Now }
            };
        }
        public async Task<int> Create(OrderCreateRequest obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderViewModel>> GetAll()
        {
            return _orderView;
        }

        public Task<PagedResult<OrderViewModel>> GetAllPaging(GetOrderPagingRequest page)
        {
            throw new NotImplementedException();
        }

        public Task<OrderViewModel> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> ListSourceCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> ListSourceProduct()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(OrderUpdateRequest obj)
        {
            throw new NotImplementedException();
        }
    }
}
