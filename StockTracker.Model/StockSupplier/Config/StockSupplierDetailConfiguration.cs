using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.StockSupplier.Config
{
    public class StockSupplierDetailConfiguration : IEntityTypeConfiguration<StockSupplierDetail>
    {
	    public void Configure(EntityTypeBuilder<StockSupplierDetail> builder)
	    {
		    builder.HasKey(i => i.StockSupplierDetailId);

						builder.HasOne(i => i.Member).WithMany(i => i.StockSupplierDetails).OnDelete(DeleteBehavior.Restrict);
						builder.HasOne(i => i.Supplier).WithOne(i => i.StockSupplierDetail).OnDelete(DeleteBehavior.Restrict);
						builder.HasOne(i => i.UnitType).WithMany(i => i.StockSupplierDetail).OnDelete(DeleteBehavior.Restrict);

						builder.HasMany(i => i.StockCore).WithOne(i => i.StockSupplierDetail).OnDelete(DeleteBehavior.Restrict);

		    builder.Property(i => i.StockSupplierDetailId).UseSqlServerIdentityColumn();
		    builder.Property(i => i.CreatedOn).HasColumnType("DATETIME").IsRequired().HasDefaultValueSql("GETDATE()");
		    builder.Property(i => i.MemberId).HasColumnType("INT").IsRequired();
		    builder.Property(i => i.Price).HasColumnType("DECIMAL").IsRequired();
		    builder.Property(i => i.SupplierId).HasColumnType("INT").IsRequired();
		    builder.Property(i => i.UnitTypeId).HasColumnType("INT").IsRequired();
		    builder.Property(i => i.Unit).HasColumnType("INT").IsRequired();
						
	    }
    }
}
