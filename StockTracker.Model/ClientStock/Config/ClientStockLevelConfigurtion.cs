﻿using System;
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
			builder.HasOne(i => i.Member);
			builder.HasOne(i => i.ClientStockItem);


			builder.Property(i => i.ClientStockItemId).HasColumnType("Int").IsRequired();
			builder.Property(i => i.CreatedOn).HasColumnType("DateTime").IsRequired();
			builder.Property(i => i.IsActive).HasColumnType("Bit").IsRequired();
			builder.Property(i => i.MemberId).HasColumnType("Int").IsRequired();
			builder.Property(i => i.Quantity).HasColumnType("Int").IsRequired();
		}
	}
}
