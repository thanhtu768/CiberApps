using Ciber.Data.EF;
using Ciber.Data.Enititys;
using Ciber.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ciber.ViewModels;
using Ciber.ViewModels.Catalog.Orders;
using Ciber.ViewModels.Common;

namespace Ciber.Services.Catalog.Orders
{
    public class ManagerOrderService : IManagerOrderService<OrderCreateRequest, OrderUpdateRequest, OrderViewModel, GetOrderPagingRequest>
    {
        private readonly CiberDbContext _context;
        public ManagerOrderService(CiberDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(OrderCreateRequest obj)
        {
            if(await IsAmountValid(obj) == false)
            {
                return -1;
            }
            var order = new Order()
            {
                CustomerID = obj.CustomerID,
                ProductID = obj.ProductID,
                Amount = obj.Amount,
                OrderDate = DateTime.Now
            };
            _context.Orders.Add(order);
             MinusQuantity(obj);
            await _context.SaveChangesAsync();
            return order.ID;
        }

        public async Task<int> Delete(int Id)
        {
            var order = await _context.Orders.FindAsync(Id);
            if (order == null) 
                throw new CiberManagerException($"Cannot find Order: {Id}");

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order.ID;
        }

        public async Task<List<OrderViewModel>> GetAll()
        {
            var query = from a in _context.Orders
                        join b in _context.Products on a.ProductID equals b.ID
                        join c in _context.Categories on b.CategoryID equals c.ID
                        join d in _context.Customers on a.CustomerID equals d.ID
                        select new { a, b, c, d };

            int totalRow = await query.CountAsync();
            var data = await query
                .Select(x => new OrderViewModel()
                {
                    ID = x.a.ID,
                    ProductID = x.b.ID,
                    ProductName = x.b.Name,
                    CustomerID = x.d.ID,
                    CustomerName = x.d.Name,
                    TotalPrice = x.b.Price * x.a.Amount,
                    Amount = x.a.Amount,
                    OrderDate = x.a.OrderDate,
                    CategoryName = x.c.Name
                }).ToListAsync();

            

            return data;
        }

        public async Task<PagedResult<OrderViewModel>> GetAllPaging(GetOrderPagingRequest page)
        {
            var query = from a in _context.Orders
                        join b in _context.Products on a.ProductID equals b.ID
                        join c in _context.Categories on b.CategoryID equals c.ID
                        join d in _context.Customers on a.CustomerID equals d.ID
                        select new { a, b, c, d };

            if (!string.IsNullOrEmpty(page.CategoryName))
            {
                query = query.Where(x => x.c.Name.Contains(page.CategoryName));
            }
             
            int totalRow = await query.CountAsync();
            var data = await query.Skip((page.PageIndex - 1)*page.PageSize).Take(page.PageSize)
                .Select(x => new OrderViewModel() {
                    ID = x.a.ID,
                    ProductID = x.b.ID,
                    ProductName = x.b.Name,
                    CustomerID = x.d.ID,
                    CustomerName = x.d.Name,
                    TotalPrice = x.b.Price * x.a.Amount,
                    Amount = x.a.Amount,
                    OrderDate = x.a.OrderDate,
                    CategoryName = x.c.Name
                }).ToListAsync();

            var pageResult = new PagedResult<OrderViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };

            return pageResult;
        }

        public async Task<OrderViewModel> GetByID(int ID)
        {
            var query = from a in _context.Orders
                        join b in _context.Products on a.ProductID equals b.ID
                        join c in _context.Categories on b.CategoryID equals c.ID
                        join d in _context.Customers on a.CustomerID equals d.ID
                        where a.ID == ID
                        select new { a, b, c, d } ;
            var data = await query 
                .Select(x => new OrderViewModel()
                {
                    ID = x.a.ID,
                    ProductID = x.b.ID,
                    ProductName = x.b.Name,
                    CustomerID = x.d.ID,
                    CustomerName = x.d.Name,
                    TotalPrice = x.b.Price * x.a.Amount,
                    Amount = x.a.Amount,
                    OrderDate = x.a.OrderDate,
                    CategoryName = x.c.Name
                }).FirstOrDefaultAsync();
            return data;
        }

        public async Task<int> Update(OrderUpdateRequest obj)
        {
            throw new NotImplementedException();
        }
        private async Task<bool> IsAmountValid(OrderCreateRequest order)
        {
            Product product = await _context.Products.FindAsync(order.ProductID);
            if (product.Quantity < order.Amount)
                return false;
            return true;
        }
        private async void MinusQuantity(OrderCreateRequest order)
        {
            Product product = await _context.Products.FindAsync(order.ProductID);
            product.Quantity -= order.Amount;
        }
        public async Task<List<Product>> ListSourceProduct()
        {
            return _context.Products.ToList(); 
        }
        public async Task<List<Customer>> ListSourceCustomer()
        {
            return _context.Customers.ToList();
        }
    }
}
