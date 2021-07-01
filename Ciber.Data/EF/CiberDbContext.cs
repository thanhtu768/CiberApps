using Ciber.Data.Configurations;
using Ciber.Data.Enititys;
using Ciber.Data.Entities;
using Ciber.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ciber.Data.EF
{
    public class CiberDbContext : IdentityDbContext<AppUser, Role, Guid>
    {
        public CiberDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            // Data Seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
