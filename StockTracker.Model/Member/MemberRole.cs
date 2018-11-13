using System.ComponentModel.DataAnnotations;
using StockTracker.Interface.Models.Member;

namespace StockTracker.Model.Member
{
    public class MemberRole : IMemberRole
    {
		[Key]
	    public int MemberRoleId { get; set; }
	    public string MemberRoleName { get; set; }
    }
}
