using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ciber.Data.Enititys
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public List<Order> Order { get; set; }
    }
}
