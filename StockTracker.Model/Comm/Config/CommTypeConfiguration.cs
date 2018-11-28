using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Comm.Config
{
    public class CommTypeConfiguration : IEntityTypeConfiguration<CommType>
    {
	    public void Configure(EntityTypeBuilder<CommType> builder)
	    {
		    builder.HasKey(i => i.CommTypeId);

		    builder.Property(i => i.CommTypeId).UseSqlServerIdentityColumn();
		    builder.Property(i => i.CommName).HasColumnType("NVARCHAR(256)").IsRequired();

		    builder.HasData(GetCommTypeSeeds());
	    }

	    private CommType[] GetCommTypeSeeds()
	    {
		    var seed = new[]
		    {
				new CommType
				{
					CommTypeId = 1,
					CommName = "SMS"
				},
				new CommType
				{
					CommTypeId = 2,
					CommName = "Email"
				},
				new CommType
				{
					CommTypeId = 3,
					CommName = "App"
				},
				new CommType
				{
					CommTypeId = 4,
					CommName = "WhatsApp"
				}
		    };

		    return seed;
	    }
    }
}
