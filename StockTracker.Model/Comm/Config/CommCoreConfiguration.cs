using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Comm.Config
{
    public class CommCoreConfiguration : IEntityTypeConfiguration<CommCore>
    {
	    public void Configure(EntityTypeBuilder<CommCore> builder)
	    {
		    builder.HasKey(i => i.CommCoreId);

		    builder.Property(i => i.CommCoreId).HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
		    builder.Property(i => i.CommDetailId).HasColumnType("Int").IsRequired();
		    builder.Property(i => i.ChangedOn).HasColumnType("DateTime").IsRequired().HasDefaultValueSql("GetDate()");
		    builder.Property(i => i.CreatedOn).HasColumnType("DateTime").IsRequired().HasDefaultValueSql("GetDate()");
		    builder.Property(i => i.CommSendStatusTypeId).HasColumnType("Int").IsRequired();
		    builder.Property(i => i.CommTypeId).HasColumnType("Int").IsRequired();

		    builder.HasOne(i => i.CommDetail);
		    builder.HasOne(i => i.CommSendStatusType);
	    }
    }
}
