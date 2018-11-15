using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Comm.Config
{
    public class CommErrorConfiguration : IEntityTypeConfiguration<CommError>
    {
	    public void Configure(EntityTypeBuilder<CommError> builder)
	    {
		    builder.HasKey(i => i.CommErrorId);

		    builder.Property(i => i.CommErrorId).HasColumnType("INT").IsRequired().UseSqlServerIdentityColumn();
		    builder.Property(i => i.CreatedOn).HasColumnType("DATETIME").IsRequired().HasDefaultValueSql("GETDATE()");
		    builder.Property(i => i.Exception).HasColumnType("NVARCHAR(MAX)").IsRequired();
		    builder.Property(i => i.Note).HasColumnType("NVARCHAR(2048)").IsRequired();
		    builder.Property(i => i.StackTrace).HasColumnType("NVARCHAR(MAX)").IsRequired();
	    }
    }
}
