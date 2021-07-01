using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Data.Enititys
{
    public class Order : EntityBase
    {
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
