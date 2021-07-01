using Ciber.Data.Enititys;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        //public string Address { get; set; }
        public Customer Customer { get; set; }
    }
}
