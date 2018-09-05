using System.ComponentModel.DataAnnotations;
using StockTracker.Interface.Models.User;

namespace StockTracker.Model.User
{
    public class MemberRole : IMemberRole
    {
		[Key]
	    public int MemberRoleId { get; set; }
	    public string MemberRoleName { get; set; }
    }
}
