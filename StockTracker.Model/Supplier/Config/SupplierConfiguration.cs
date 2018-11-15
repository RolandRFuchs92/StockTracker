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

		    builder.Property(i => i.SupplierId).HasColumnType("INT").IsRequired().UseSqlServerIdentityColumn();
	    }
    }
}
