using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Clients.Config
{
    public class ClientSettingsConfiguration : IEntityTypeConfiguration<ClientSettings>
    {
	    public void Configure(EntityTypeBuilder<ClientSettings> builder)
	    {
		    builder.HasKey(i => i.ClientSettingsId);
		    builder.HasOne(i => i.Client).WithOne(i => i.ClientSettings);

		    builder.Property(i => i.ClientId).IsRequired().HasColumnType("Int");
		    builder.Property(i => i.CanAnyoneAddStock).IsRequired().HasColumnType("Bit");
		    builder.Property(i => i.CanEmailManagers).IsRequired().HasColumnType("Bit");
		    builder.Property(i => i.CloseTime).IsRequired().HasColumnType("DateTime");
		    builder.Property(i => i.OpenTime).IsRequired().HasColumnType("DateTime");
		    builder.Property(i => i.TotalUsers).IsRequired(false).HasColumnType("Int");

	    }
    }
}
