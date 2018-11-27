using StockTracker.Interface.Models.Member;

namespace StockTracker.Model.Members
{
    public class MemberRole : IMemberRole
    {
	    public int MemberRoleId { get; set; }
	    public string MemberRoleName { get; set; }
        public bool IsActive { get; set; }

        public Member Member { get; set; }
    }
}
