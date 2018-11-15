using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Member.Config
{
    public class MemberRoleConfiguration : IEntityTypeConfiguration<MemberRole>
    {
	    public void Configure(EntityTypeBuilder<MemberRole> builder)
	    {
		    builder.HasKey(i => i.MemberRoleId);

		    builder.Property(i => i.MemberRoleId).IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
		    builder.Property(i => i.MemberRoleName).IsRequired().HasColumnType("NVARCHAR(256)");

		    builder.HasData(GetMemberRoleSeed());
	    }

	    private MemberRole[] GetMemberRoleSeed()
	    {
		    var seed = new[]
		    {
				new MemberRole
				{
					MemberRoleId = 1,
					MemberRoleName = "Managing Director"
				}, 
				new MemberRole
				{
					MemberRoleId = 2,
					MemberRoleName = "Admin"
				},
				new MemberRole
				{
					MemberRoleId = 3,
					MemberRoleName = "Team Leader"
				},
				new MemberRole
				{
					MemberRoleId = 4,
					MemberRoleName = "Manager"
				},
				new MemberRole
				{
					MemberRoleId = 5,
					MemberRoleName = "Waiter"
				},
				new MemberRole
				{
					MemberRoleId = 6,
					MemberRoleName = "Chef"
				},
				new MemberRole
				{
					MemberRoleId = 7,
					MemberRoleName = "Sculler"
				},
				new MemberRole
				{
					MemberRoleId = 8,
					MemberRoleName = "Staff"
				}
		    };

		    return seed;
	    }
    }
}
