using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Data.Enititys
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Product { get; set; }
    }
}
