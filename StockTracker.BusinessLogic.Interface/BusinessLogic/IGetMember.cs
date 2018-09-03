using System.Collections.Generic;
using StockTracker.Model;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic
{
    public interface IGetMembers
    {
	    Member GetMemberByMemberId(int memberId);
	    Member GetMemberByPersonId(int personId);
	    List<Member> GetMembersByMemberRoleId(int memberRoleId);
    }
}
