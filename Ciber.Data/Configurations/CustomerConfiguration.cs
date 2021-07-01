using Ciber.Data.Enititys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.ToTable("Cutomers");
            builder.HasKey(a => a.ID);
            builder.HasOne(x => x.AppUser).WithOne(x => x.Customer).HasForeignKey<Customer>(x => x.UserID);
        }
    }
}
