using Ciber.ViewModels.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.ViewModels.Catalog.Orders
{
    public class OrderCreateRequest:PagingRequestBase
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public string  OrderName { get; set; }
    }
    public class OrderCreateRequestValidator : AbstractValidator<OrderCreateRequest> 
    {
        public OrderCreateRequestValidator()
        {
            RuleFor(a => a.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
        }
    }

    public class OrderUpdateRequest
    {
    }
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public string CategoryName { get; set; }
    }
    public class GetOrderPagingRequest : PagingRequestBase
    {
        public string CategoryName { get; set; }
    }
}
