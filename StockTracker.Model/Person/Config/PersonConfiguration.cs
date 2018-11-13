using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Person.Config
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
	    public void Configure(EntityTypeBuilder<Person> builder)
	    {
		    builder.HasKey(i => i.PersonId);

		    builder.Property(i => i.PersonId).IsRequired().ValueGeneratedOnAdd().HasColumnType("INT");
		    builder.Property(i => i.Email).IsRequired().HasColumnType("NVARCHAR(256)");
		    builder.Property(i => i.Mobile).IsRequired().HasColumnType("NCARCHAR(20)");
		    builder.Property(i => i.PersonName).IsRequired().HasColumnType("NVARCHAR(256");
		    builder.Property(i => i.PersonSurname).IsRequired().HasColumnType("NVARCHAR(256)");
		    builder.Property(i => i.WhatsApp).IsRequired().HasColumnType("NVARCHAR(20)");
	    }
    }
}
