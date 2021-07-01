using Ciber.ViewModels.Catalog.Orders;
using Ciber.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.WebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;
        public OrderController(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;

        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetOrderPagingRequest() {
                BearerToken = HttpContext.Session.GetString("Token"),
                CategoryName = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _orderApiClient.GetOrderPaging(request);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ListSourceProduct =  new SelectList(await _orderApiClient.GetListProduct(HttpContext.Session.GetString("Token")),"ID","Name");
            ViewBag.ListSourceCustomer =  new SelectList(await _orderApiClient.GetListCustomer(HttpContext.Session.GetString("Token")), "ID", "Name");
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateRequest request)
        {
            ViewBag.ListSourceProduct = new SelectList(await _orderApiClient.GetListProduct(HttpContext.Session.GetString("Token")), "ID", "Name");
            ViewBag.ListSourceCat = new SelectList(await _orderApiClient.GetListCustomer(HttpContext.Session.GetString("Token")), "ID", "Name");
            if (!ModelState.IsValid)
            {
                return PartialView(ModelState);
            }
            request.BearerToken = HttpContext.Session.GetString("Token");
            var result = await _orderApiClient.CreateOrder(request);
            if(result)
                return RedirectToAction("Index");
            return PartialView(request);
        }
    }
}
