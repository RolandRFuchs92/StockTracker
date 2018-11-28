using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.ClientStock.Config
{
	public class ClientStockLevelConfigurtion : IEntityTypeConfiguration<ClientStockLevel>
	{
		public void Configure(EntityTypeBuilder<ClientStockLevel> builder)
		{
			builder.HasKey(i => i.ClientStockLevelId);

			builder.HasOne(i => i.Member).WithOne().OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(i => i.ClientStockItem).WithOne().OnDelete(DeleteBehavior.Restrict);


			builder.Property(i => i.ClientStockLevelId).UseSqlServerIdentityColumn();
			builder.Property(i => i.ClientStockItemId).HasColumnType("Int").IsRequired();
			builder.Property(i => i.CreatedOn).HasColumnType("DateTime").IsRequired().HasDefaultValueSql("GETDATE()");
			builder.Property(i => i.IsActive).HasColumnType("Bit").IsRequired();
			builder.Property(i => i.MemberId).HasColumnType("Int").IsRequired();
			builder.Property(i => i.Quantity).HasColumnType("Int").IsRequired();
		}
	}
}
