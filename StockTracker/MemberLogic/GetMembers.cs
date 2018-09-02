using StockTracker.Interface.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.User;

namespace StockTracker.BusinessLogic.MemberLogic
{
    public class GetMembers : IGetMember
    {
	    private readonly IStockTrackerContext _db;

	    public GetMembers(IStockTrackerContext db)
	    {
		    _db = db;
	    }

	    public IMember GetMemberByMemberId(int memberId)
	    {
		    return _db.Members.FirstOrDefault(i => i.MemberId == memberId);
	    }

	    public IMember GetMemberByPersonId(int personId)
	    {
		    throw new NotImplementedException();
	    }

	    public List<IMember> GetMembersByMemberRoleId(int memberRoleId)
	    {
		    throw new NotImplementedException();
	    }
    }
}
