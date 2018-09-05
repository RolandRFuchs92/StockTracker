using System.Collections.Generic;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Member
{
    public interface IGetMembers
    {
	    Model.User.Member GetMemberByMemberId(int memberId);
	    Model.User.Member GetMemberByPersonId(int personId);
	    List<Model.User.Member> GetMembersByMemberRoleId(int memberRoleId);
    }
}
