using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Services.System.Logger
{
    public static class LoggerServiceConfig
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
