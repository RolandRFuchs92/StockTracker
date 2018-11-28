using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Members.Config
{
    public class MemberRoleConfiguration : IEntityTypeConfiguration<MemberRole>
    {
	    public void Configure(EntityTypeBuilder<MemberRole> builder)
	    {
		    builder.HasKey(i => i.MemberRoleId);

            builder.Property(i => i.MemberRoleId).UseSqlServerIdentityColumn();
            builder.Property(i => i.MemberRoleName).IsRequired().HasColumnType("NVARCHAR(256)");
	        builder.Property(i => i.IsActive).IsRequired().HasColumnType("BIT");

		    builder.HasData(GetMemberRoleSeed());
	    }

	    private MemberRole[] GetMemberRoleSeed()
	    {
		    var seed = new[]
		    {
				new MemberRole
				{
					MemberRoleId = 1,
					MemberRoleName = "Managing Director",
                    IsActive = true
				}, 
				new MemberRole
				{
					MemberRoleId = 2,
					MemberRoleName = "Admin",
                    IsActive = true
				},
                new MemberRole
				{
					MemberRoleId = 3,
					MemberRoleName = "Team Leader",
                    IsActive = true
				},
                new MemberRole
				{
					MemberRoleId = 4,
					MemberRoleName = "Manager",
                    IsActive = true
				},
                new MemberRole
				{
					MemberRoleId = 5,
					MemberRoleName = "Waiter",
                    IsActive = true
				},
                new MemberRole
				{
					MemberRoleId = 6,
					MemberRoleName = "Chef",
                    IsActive = true
				},
                new MemberRole
				{
					MemberRoleId = 7,
					MemberRoleName = "Sculler",
                    IsActive = true
				},
                new MemberRole
				{
					MemberRoleId = 8,
					MemberRoleName = "Staff",
				    IsActive = true
                }
            };

		    return seed;
	    }
    }
}
