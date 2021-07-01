using Ciber.Data.Enititys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.ToTable("Products");
            builder.HasKey(a => a.ID);
            builder.HasOne(a => a.Category).WithMany(a => a.Product).HasForeignKey(a => a.CategoryID);
        }
    }
}
