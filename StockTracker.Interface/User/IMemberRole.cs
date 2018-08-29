using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.User
{
    public interface IMemberRole
    {
        int MemberRoleId { get; set; }
		int MemberRoleName { get; set; }
    }
}
