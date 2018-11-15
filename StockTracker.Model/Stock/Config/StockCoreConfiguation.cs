using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Stock.Config
{
    public class StockCoreConfiguation : IEntityTypeConfiguration<StockCore>
    {
	    public void Configure(EntityTypeBuilder<StockCore> builder)
	    {
		    builder.HasKey(i => i.StockCoreId);

		    builder.HasOne(i => i.StockType).WithOne(i => i.StockCore).OnDelete(DeleteBehavior.Restrict);
		    builder.HasOne(i => i.StockCategory).WithOne(i => i.StockCore).OnDelete(DeleteBehavior.Restrict);
		    builder.HasOne(i => i.StockSupplierDetail).WithOne(i => i.StockCore).OnDelete(DeleteBehavior.Restrict);

		    builder.Property(i => i.StockCoreId).IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
		    builder.Property(i => i.CreatedOn).IsRequired().HasColumnType("DATETIME").ValueGeneratedOnAdd();
		    builder.Property(i => i.StockCategoryId).IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
		    builder.Property(i => i.StockCoreName).IsRequired().HasColumnType("NVARCHAR(250)").ValueGeneratedOnAdd();
		    builder.Property(i => i.StockSupplierDetailId).IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
		    builder.Property(i => i.StockTypeId).IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
	    }
    }
}
