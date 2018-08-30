using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.User;

namespace StockTracker.Model
{
    public class MemberRole : IMemberRole
    {
	    public int MemberRoleId { get; set; }
	    public int MemberRoleName { get; set; }
    }
}
