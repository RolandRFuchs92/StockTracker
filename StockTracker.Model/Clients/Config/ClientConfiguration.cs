using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTracker.Model.Clients;

namespace StockTracker.Model.Config.Clients
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasKey(i => i.ClientId);
			builder.Property(i => i.IsActive).IsRequired(true).HasColumnType("Bit");
			builder.Property(i => i.Email).IsRequired(true).HasColumnType("Nvarchar").HasMaxLength(250);
			builder.Property(i => i.ContactNumber).IsRequired(true).HasColumnType("Nvarchar").HasMaxLength(20);
			builder.Property(i => i.Address).IsRequired(true).HasColumnType("Nvarchar").HasMaxLength(250);
			builder.Property(i => i.ClientName).IsRequired(true).HasColumnType("Nvarchar").HasMaxLength(100);
			builder.Property(i => i.CreatedOn).IsRequired(true).HasColumnType("DateTime").HasDefaultValueSql("GetDate()");
			builder.Property(i => i.LastCheckup).IsRequired(false).HasColumnType("DateTime");
			builder.Property(i => i.IsDeleted).IsRequired(false).HasColumnType("Bit");

			builder.HasOne<ClientSettings>().WithOne(i => i.Client);
		}
	}
}
