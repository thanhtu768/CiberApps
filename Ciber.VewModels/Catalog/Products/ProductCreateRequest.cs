using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductEditRequest
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
