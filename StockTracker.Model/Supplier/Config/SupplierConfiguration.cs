using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Supplier.Config
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
	    public void Configure(EntityTypeBuilder<Supplier> builder)
	    {
		    builder.HasKey(i => i.SupplierId);

		    builder.HasOne(i => i.SupplierType).WithMany(i => i.Suppliers);

		    builder.Property(i => i.SupplierId).UseSqlServerIdentityColumn();
		    builder.Property(i => i.Email).HasColumnType("NVARCHAR(256)").IsRequired(false);
		    builder.Property(i => i.Address).HasColumnType("NVARCHAR(1024)").IsRequired(false);
		    builder.Property(i => i.ContactNumber).HasColumnType("NVARCHAR(256)").IsRequired(false);
		    builder.Property(i => i.SupplierLocation).HasColumnType("NVARCHAR(256)").IsRequired(false);
		    builder.Property(i => i.SupplierTypeId).HasColumnType("INT").IsRequired();
		    builder.Property(i => i.SupplierName).HasColumnType("NVARCHAR(256)").IsRequired();
	    }
    }
}
