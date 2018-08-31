using System;

namespace StockTracker.Interface.Models.User
{
    public interface IMember
    {
        int MemberId { get; set; }
		int PersonId { get; set; }
		int MemberRoleId { get; set; }
		int IsActive { get; set; }
		DateTime LastActiveDate { get; set; }

		IPerson Person { get; set; }
		IMemberRole MemberRole { get; set; }
    }
}
