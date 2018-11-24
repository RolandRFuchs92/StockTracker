using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Persons.Config
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
	    public void Configure(EntityTypeBuilder<Person> builder)
	    {
		    builder.HasKey(i => i.PersonId);

	        builder.HasOne(i => i.Member).WithOne(i => i.Person);

		    builder.Property(i => i.PersonId).IsRequired().HasColumnType("INT").UseSqlServerIdentityColumn();
		    builder.Property(i => i.Email).IsRequired().HasColumnType("NVARCHAR(256)");
		    builder.Property(i => i.Mobile).IsRequired().HasColumnType("NVARCHAR(20)");
		    builder.Property(i => i.PersonName).IsRequired().HasColumnType("NVARCHAR(256)");
		    builder.Property(i => i.PersonSurname).IsRequired().HasColumnType("NVARCHAR(256)");
		    builder.Property(i => i.WhatsApp).IsRequired().HasColumnType("NVARCHAR(20)");
	    }
    }
}
