using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Clients.Config
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasKey(i => i.ClientId);

			builder.Property(i => i.ClientId).ValueGeneratedOnAdd();
			builder.Property(i => i.IsActive).IsRequired(true).HasColumnType("Bit");
			builder.Property(i => i.Email).IsRequired(true).HasColumnType("Nvarchar").HasMaxLength(250);
			builder.Property(i => i.ContactNumber).IsRequired(true).HasColumnType("Nvarchar").HasMaxLength(20);
			builder.Property(i => i.Address).IsRequired(true).HasColumnType("Nvarchar").HasMaxLength(250);
			builder.Property(i => i.ClientName).IsRequired(true).HasColumnType("Nvarchar").HasMaxLength(100);
			builder.Property(i => i.CreatedOn).IsRequired(true).HasColumnType("DateTime").HasDefaultValueSql("GetDate()");
			builder.Property(i => i.LastCheckup).IsRequired(false).HasColumnType("DateTime");
			builder.Property(i => i.IsDeleted).IsRequired(false).HasColumnType("Bit");

			builder.HasOne<ClientSettings>().WithOne(i => i.Client);
			builder.HasMany(i => i.Member).WithOne(i => i.Client);
		}
	}
}
