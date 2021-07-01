using Ciber.Data.Enititys;
using Ciber.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        // Seed Identity
        const string CUS_ID = "334D0EC7-5F04-4C52-8BF6-3957E82466D9";
        // any guid, but nothing is against to use the same one
        const string ROLE_ID = "D177A779-B8CB-460F-999F-EFA33E38AE30";
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                    new Customer() { ID = 1, Name = "Thanh Tu", Address = "HaNoi", UserID = new Guid(CUS_ID)}
                );
            modelBuilder.Entity<Category>().HasData(
                    new Category() { ID = 1, Name = "Paper", Description = "A1,A2,A3,A4" },
                    new Category() { ID = 2, Name = "Pencil", Description = "pencil" }
                );
            modelBuilder.Entity<Product>().HasData(
                    new Product() { ID = 1, Name = "A4 Canon", CategoryID = 1, Description = "A4 Canon Description", Price = 10000, Quantity = 100 },
                    new Product() { ID = 2, Name = "A4 Casio", CategoryID = 1, Description = "A4 Casio Description", Price = 14000, Quantity = 10 },
                    new Product() { ID = 3, Name = "Pencil 1", CategoryID = 2, Description = "Pencil Description", Price = 15000, Quantity = 100 }
                );
            modelBuilder.Entity<Order>().HasData(
                    new Order() {ID = 1, CustomerID = 1, ProductID = 1, Amount = 2, OrderDate = DateTime.Now },
                    new Order() { ID = 2, CustomerID = 1, ProductID = 2, Amount = 32, OrderDate = DateTime.Now },
                    new Order() { ID = 3, CustomerID = 1, ProductID = 3, Amount = 11, OrderDate = DateTime.Now }
                );

            
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = new Guid(ROLE_ID),
                Name = "customer",
                NormalizedName = "customer",
                Description = "Customer Role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = new Guid(CUS_ID),
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "thanhtu@gmail.com",
                NormalizedEmail = "thanhtu@gmail.com",
                PhoneNumber = "0941079795",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123qwe"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = new Guid(ROLE_ID),
                UserId = new Guid(CUS_ID)
            });
        }
    }
}
