using Ciber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Data.Enititys
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Order> Order { get; set; }
        public Guid UserID { get; set; }
        public AppUser AppUser { get; set; }
    }

}
