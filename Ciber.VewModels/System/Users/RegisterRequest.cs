using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.ViewModels.System.Users
{
    public  class RegisterRequest
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
