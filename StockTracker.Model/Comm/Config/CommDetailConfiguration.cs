using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Comm.Config
{
    public class CommDetailConfiguration : IEntityTypeConfiguration<CommDetail>
    {
	    public void Configure(EntityTypeBuilder<CommDetail> builder)
	    {
		    builder.HasKey(i => i.CommDetailId);

		    builder.HasOne(i => i.Member).WithOne().OnDelete(DeleteBehavior.Restrict);
		    builder.HasOne(i => i.CommError).WithOne().OnDelete(DeleteBehavior.Restrict);

		    builder.Property(i => i.CommDetailId).HasColumnType("INT").IsRequired().ValueGeneratedOnAdd();
		    builder.Property(i => i.CommErrorId).HasColumnType("INT").IsRequired();
		    builder.Property(i => i.MemberId).HasColumnType("INT").IsRequired();
		    builder.Property(i => i.Response).HasColumnType("NVARCHAR(2048)").IsRequired(false);
		    builder.Property(i => i.Subject).HasColumnType("NVARCHAR(256)").IsRequired();
		    builder.Property(i => i.Message).HasColumnType("NVARCHAR(MAX)").IsRequired();
		    builder.Property(i => i.Recipients).HasColumnType("NVARCHAR(2048)").IsRequired();
		    builder.Property(i => i.Sender).HasColumnType("NVARCHAR(200)").IsRequired();
	    }
    }
}

