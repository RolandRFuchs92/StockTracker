using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.BusinessLogic.Interface.BusinessLogic;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Members;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.User;
using StockTracker.Model;
using StockTracker.Model.User;

namespace StockTracker.BusinessLogic.MemberLogic
{
    public class GetMembers : IGetMembers
    {
	    private readonly IStockTrackerContext _db;

	    public GetMembers(IStockTrackerContext db)
	    {
		    _db = db;
	    }

	    public Member GetMemberByMemberId(int memberId)
	    {
		    return _db.Members.FirstOrDefault(i => i.MemberId == memberId);
	    }

	    public Member GetMemberByPersonId(int personId)
	    {
		    throw new NotImplementedException();
	    }

	    public List<Member> GetMembersByMemberRoleId(int memberRoleId)
	    {
		    throw new NotImplementedException();
	    }

	    public List<Member> GetMembers(int clientId)
	    {
		    throw new NotImplementedException();
	    }

	    public List<Member> GetMembers(int clientId, int memberRoleId)
	    {
		    throw new NotImplementedException();
	    }

	    public List<Member> GetAllMembers(int clientId)
	    {
		    throw new NotImplementedException();
	    }

	    public List<Member> GetAllMembers(int clientId, int memberRoleId)
	    {
		    throw new NotImplementedException();
	    }
    }
}
