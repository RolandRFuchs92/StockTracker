using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Member.Config
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
	    public void Configure(EntityTypeBuilder<Member> builder)
	    {
		    builder.HasKey(i => i.MemberId);

		    builder.HasOne(i => i.Client);
		    builder.HasOne(i => i.MemberRole);
		    builder.HasOne(i => i.Person);

		    builder.Property(i => i.MemberId).IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
		    builder.Property(i => i.IsActive).IsRequired().HasColumnType("BIT");
		    builder.Property(i => i.ClientId).IsRequired().HasColumnType("INT");
		    builder.Property(i => i.MemberRoleId).IsRequired().HasColumnType("INT");
		    builder.Property(i => i.LastActiveDate).IsRequired(false).HasColumnType("DATETIME");
	    }
    }
}
