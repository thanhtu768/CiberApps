using Ciber.ViewModels.System.Users;
using Ciber.WebApp.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                 option =>
                 {
                     option.LoginPath = "/user/login";
                     option.AccessDeniedPath = "/user/login";
                     option.Cookie.HttpOnly = true;
                     option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                     option.SlidingExpiration = true;
                 }
                 );
            services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(30);
                }
            );
            services.AddAuthorization();
            //DI
            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IOrderApiClient, OrderApiClient>();

            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseCookiePolicy();
            app.UseAuthentication();
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
