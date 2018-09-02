using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.User;

namespace StockTracker.Model
{
    public class MemberRole : IMemberRole
    {
		[Key]
	    public int MemberRoleId { get; set; }
	    public string MemberRoleName { get; set; }
    }
}
