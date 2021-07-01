using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ciber.Data.Enititys
{
    public class EntityBase
    {
        [Key]
        public int ID { get; set; }
    }
}
