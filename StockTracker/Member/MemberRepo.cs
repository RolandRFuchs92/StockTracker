using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Member;
using StockTracker.Interface.Models.Person;
using StockTracker.Repository.Interface.Members;

namespace StockTracker.Repository.Member
{
    public class MemberRepo  :IMemberRepo
    {
        private IStockTrackerContext _db;

        public MemberRepo(IStockTrackerContext db)
        {
            _db = db;
        }

        public IMember Add(IMember member)
        {
            try
            {
                if (!_db.Clients.Any(i => i.ClientId == member.ClientId))
                    return null;
                

                _db.Members.Add((Model.Members.Member)member);
                var memberId = ((StockTrackerContext) _db).SaveChanges();
                return _db.Members.FirstOrDefault(i => i.MemberId == memberId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IMember Edit(IMember member)
        {
            throw new NotImplementedException();
        }

        public IMember ChangeRole(int memberId, int memberRoleId)
        {
            throw new NotImplementedException();
        }

        public IMember ChangeClient(int memberId, int clientId)
        {
            throw new NotImplementedException();
        }

        public IMember LastActiveDate(int memberId)
        {
            throw new NotImplementedException();
        }

        public IMember EditPerson(int memberId, IPerson person)
        {
            throw new NotImplementedException();
        }
    }
}
