using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTracker.Model.Clients;

namespace StockTracker.Model.ClientStock.Config
{
    public class ClientStockItemConfiguration : IEntityTypeConfiguration<ClientStockItem>
    {
	    public void Configure(EntityTypeBuilder<ClientStockItem> builder)
	    {
		    builder.HasKey(i => i.ClientStockItemId);
		    builder.HasOne(i => i.Client);
		    builder.HasOne(i => i.StockCore);

		    builder.Property(i => i.ClientId).HasColumnType("Int").IsRequired();
		    builder.Property(i => i.IsActive).HasColumnType("Bit").IsRequired();
		    builder.Property(i => i.CreatedOn).IsRequired().HasColumnType("DateTime").HasDefaultValueSql("GetDate()");
		    builder.Property(i => i.StockMax).IsRequired().HasColumnType("Int");
		    builder.Property(i => i.StockMin).IsRequired().HasColumnType("Int");
		    builder.Property(i => i.StockCoreId).HasColumnType("Int").IsRequired();
	    }
    }
}
