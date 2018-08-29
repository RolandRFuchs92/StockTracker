using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.User
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
