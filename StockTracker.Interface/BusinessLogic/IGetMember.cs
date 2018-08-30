using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.User;

namespace StockTracker.Interface.BusinessLogic
{
    public interface IGetMember
    {
	    IMember GetMemberByMemberId(int memberId);
	    IMember GetMemberByPersonId(int personId);
	    List<IMember> GetMembersByMemberRoleId(int memberRoleId);
    }
}
