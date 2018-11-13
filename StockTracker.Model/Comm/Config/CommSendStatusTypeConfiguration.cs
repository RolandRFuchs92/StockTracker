using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Comm.Config
{
    public class CommSendStatusTypeConfiguration : IEntityTypeConfiguration<CommSendStatusType>
    {
	    public void Configure(EntityTypeBuilder<CommSendStatusType> builder)
	    {
		    builder.HasKey(i => i.CommSendStatusTypeId);

		    builder.Property(i => i.CommSendStatusTypeId).HasColumnType("INT").ValueGeneratedOnAdd();
		    builder.Property(i => i.CommSendStatusName).HasColumnType("NVARCHAR(200)").IsRequired();

		    builder.HasData(GetSeedStatusTypes());
	    }

	    private CommSendStatusType[] GetSeedStatusTypes()
	    {
		    var seed = new[]
		    {
				new CommSendStatusType
				{
					CommSendStatusTypeId = 1,
					CommSendStatusName = "Qued"
				},
			    new CommSendStatusType
			    {
					CommSendStatusTypeId = 2,
				    CommSendStatusName = "Processing"
				},
			    new CommSendStatusType
			    {
					CommSendStatusTypeId = 3,
				    CommSendStatusName = "Sent"
				},
			    new CommSendStatusType
			    {
					CommSendStatusTypeId = 4,
				    CommSendStatusName = "Failed"
				},
			    new CommSendStatusType
			    {
					CommSendStatusTypeId = 5,
				    CommSendStatusName = "Pending"
				},
			};

		    return seed;
	    }
    }
}
