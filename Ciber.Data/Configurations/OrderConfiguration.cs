using Ciber.Data.Enititys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.HasKey("ID");
            builder.HasOne<Product>(a => a.Product).WithMany(a => a.Order).HasForeignKey(a => a.ProductID);
            builder.HasOne<Customer>(a => a.Customer).WithMany(a => a.Order).HasForeignKey(a => a.CustomerID);
        }
    }
}
