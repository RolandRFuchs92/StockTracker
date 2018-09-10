using System.Collections.Generic;
using StockTracker.Model.User;

namespace StockTracker.Repository.Interface.BusinessLogic.Members
{
    public interface IGetMembers
    {
	    Member GetMemberByMemberId(int memberId);
	    Member GetMemberByPersonId(int personId);
	    List<Member> Get(int clientId);
	    List<Member> Get(int clientId, int memberRoleId);
	    List<Member> GetAllMembers(int clientId);
	    List<Member> GetAllMembers(int clientId, int memberRoleId);
    }
}
