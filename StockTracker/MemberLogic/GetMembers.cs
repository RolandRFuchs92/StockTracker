using System.Collections.Generic;
using System.Linq;
using StockTracker.Context.Interface;
using StockTracker.Model.User;
using StockTracker.Repository.Interface.BusinessLogic.Members;

namespace StockTracker.Repository.MemberLogic
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
		    return _db.Members.FirstOrDefault(i => i.PersonId == personId);
	    }

	    public List<Member> Get(int clientId)
	    {
		    return _db.Members.Where(i => i.ClientId == clientId && i.IsActive).ToList();
	    }

		public List<Member> Get(int clientId, int memberRoleId)
	    {
		    return _db.Members.Where(i => i.MemberRoleId == memberRoleId && i.ClientId == clientId && i.IsActive).ToList();
	    }

	    public List<Member> GetAllMembers(int clientId)
	    {
		    return _db.Members.Where(i => i.ClientId == clientId && i.IsActive).ToList();
	    }

	    public List<Member> GetAllMembers(int clientId, int memberRoleId)
	    {
		    return _db.Members.Where(i => i.MemberRoleId == memberRoleId && i.ClientId == clientId && i.IsActive).ToList();
	    }
    }
}
