using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Member;
using StockTracker.Interface.Models.Person;
using StockTracker.Model.Persons;
using StockTracker.Repository.Interface.Members;

namespace StockTracker.Repository.Member
{
    public class MemberRepo : IMemberRepo
    {
        private IStockTrackerContext _db;

        public MemberRepo(IStockTrackerContext db)
        {
            _db = db;
        }

        public IMember Add(IMember member, IPerson person)
        {
            try
            {
                if (!_db.Clients.Any(i => i.ClientId == member.ClientId) || person == null)
                    return null;

                _db.Persons.Add((Person)person);
                member.PersonId = person.PersonId;

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
            try
            {
                var isValidClient = _db.Clients.Any(i => i.ClientId == member.ClientId || member.ClientId == 0) ;
                var isValidMemberRoleId = _db.MemberRoles.Any(i => i.MemberRoleId == member.MemberRoleId || member.MemberRoleId == 0) ;
                var isValidPersonId = _db.Persons.Any(i => i.PersonId == member.PersonId || member.PersonId == 0) ;

                if (!isValidClient || !isValidMemberRoleId || !isValidPersonId)
                    return null;

                var oldMember = _db.Members.FirstOrDefault(i => i.MemberId == member.MemberId);
                oldMember.PersonId = member.PersonId == 0 ? oldMember.PersonId : member.PersonId;
                oldMember.MemberRoleId = member.MemberRoleId == 0 ? oldMember.MemberRoleId : member.MemberRoleId;
                oldMember.ClientId = member.ClientId == 0 ? oldMember.ClientId : member.ClientId;
                oldMember.LastActiveDate = member.LastActiveDate == null ? oldMember.LastActiveDate : member.LastActiveDate;
                oldMember.IsActive = member.IsActive;

                var memberId = ((StockTrackerContext)_db).SaveChanges();
                return _db.Members.FirstOrDefault(i => i.MemberId == memberId);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IMember ChangeRole(int memberId, int memberRoleId)
        {
            try
            {
                

            }
            catch (Exception e)
            {
                return null;
            }
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
