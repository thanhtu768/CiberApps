using Ciber.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.WebApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
