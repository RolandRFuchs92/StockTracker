using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.User
{
    public interface IMemberRole
    {
		[Key]
        int MemberRoleId { get; set; }
		string MemberRoleName { get; set; }
    }
}
