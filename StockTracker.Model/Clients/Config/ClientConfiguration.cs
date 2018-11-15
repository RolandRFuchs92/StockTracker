using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Clients.Config
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasKey(i => i.ClientId);

			builder.HasOne<ClientSettings>().WithOne(i => i.Client).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(i => i.Member).WithOne(i => i.Client).OnDelete(DeleteBehavior.Restrict);

			builder.Property(i => i.ClientId).UseSqlServerIdentityColumn();
			builder.Property(i => i.IsActive).IsRequired().HasColumnType("BIT");
			builder.Property(i => i.Email).IsRequired().HasColumnType("NVARCHAR(250)").HasMaxLength(250);
			builder.Property(i => i.ContactNumber).IsRequired().HasColumnType("NVARCHAR(20)").HasMaxLength(20);
			builder.Property(i => i.Address).IsRequired(false).HasColumnType("NVARCHAR(250)").HasMaxLength(250);
			builder.Property(i => i.ClientName).IsRequired().HasColumnType("NVARCHAR(100)");
			builder.Property(i => i.CreatedOn).IsRequired().HasColumnType("DateTime").HasDefaultValueSql("GetDate()");
			builder.Property(i => i.LastCheckup).IsRequired(false).HasColumnType("DateTime");
			builder.Property(i => i.IsDeleted).IsRequired(false).HasColumnType("Bit");
		}
	}
}
