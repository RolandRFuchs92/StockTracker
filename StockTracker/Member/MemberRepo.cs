﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Member;
using StockTracker.Interface.Models.Person;
using StockTracker.Model.Persons;
using StockTracker.Repository.Enums;
using StockTracker.Repository.Interface.Members;

namespace StockTracker.Repository.Member
{
    public class MemberRepo : IMemberRepo
    {
        private IStockTrackerContext _db;
        private ILoggerAdapter<MemberRepo> _log;

        public MemberRepo(IStockTrackerContext db, ILoggerAdapter<MemberRepo> log)
        {
            _db = db;
            _log = log;
        }

        public IMember Add(IMember member, IPerson person)
        {
            try
            {
                if (!_db.Clients.Any(i => i.ClientId == member.ClientId) || person == null)
                    return BlockCheck("Invalid ClientId or Person was null.");

                _db.Persons.Add((Person)person);
                member.PersonId = person.PersonId;

                _db.Members.Add((Model.Members.Member)member);
                var memberId = ((StockTrackerContext) _db).SaveChanges();

                _log.LogInformation((int)LoggingEvent.Create, "Created new Member");

                return _db.Members.FirstOrDefault(i => i.MemberId == memberId);
            }
            catch (Exception e)
            {
                _log.LogError((int)LoggingEvent.Create, e, "Create Member/Person");
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
								_log.LogInformation((int)LoggingEvent.Create, $"Edited member with Member[{member.MemberId}].");

                return _db.Members.FirstOrDefault(i => i.MemberId == memberId);

						}
            catch (Exception e)
            {
								_log.LogError((int)LoggingEvent.Update, e, $"An error occured while editing Member[{member.MemberId}].");
                return null;
            }
        }

        public IMember ChangeRole(int memberId, int memberRoleId)
        {
            try
            {
                var isValidMemberRole = _db.MemberRoles.Any(i => i.MemberRoleId == memberRoleId);
                if (!isValidMemberRole)
                    return null;

                var member = _db.Members.FirstOrDefault(i => i.MemberId == memberId);
								var oldMemberRoleId = member.MemberRoleId;
                member.MemberRoleId = memberRoleId;
								_log.LogInformation((int)LoggingEvent.Create, $"Changed member[{memberId}] to MemberRole[{oldMemberRoleId}] to MemberRole[{memberRoleId}].");

								((StockTrackerContext) _db).SaveChanges();

                return _db.Members.FirstOrDefault(i => i.MemberId == memberId);
            }
            catch (Exception e)
            {
								_log.LogError((int)LoggingEvent.Update, e, $"An error occured while changing Member[{memberId}] to MemberRole[{memberRoleId}].");
                return null;
						}
        }

        public IMember ChangeClient(int memberId, int clientId)
        {
            try
            {
                var isValidClientId = _db.Clients.Any(i => i.ClientId == clientId);

                if (!isValidClientId)
                    return null;

                var member = _db.Members.FirstOrDefault(i => i.MemberId == memberId);
								var oldMembersClientId = member.ClientId;
                member.ClientId = clientId;

                memberId = ((StockTrackerContext) _db).SaveChanges();
								_log.LogInformation((int)LoggingEvent.Create, $"Changed Member[{memberId}] from Client[{oldMembersClientId}] to Client[{clientId}].");

                return _db.Members.FirstOrDefault(i => i.MemberId == memberId);
            }
            catch (Exception e)
            {
								_log.LogError((int)LoggingEvent.Update, e, $"An error occured while changing the Member[{memberId}] ClientId to Client[{clientId}]");
                return null;
						}
        }

        public IMember LastActiveDate(int memberId)
        {
            try
            {
                var member = _db.Members.FirstOrDefault(i => i.MemberId == memberId);
                member.LastActiveDate = DateTime.Now;

                ((StockTrackerContext) _db).SaveChanges();
								_log.LogInformation((int)LoggingEvent.Create, $"Updated Member[{memberId}] LastActiveDate.");

                return member;
						}
            catch (Exception e)
            {
								_log.LogError((int)LoggingEvent.Update, e, $"An error while updating a Member[{memberId}] LastActiveDate.");
                return null;
						}
        }

        public IMember EditPerson(int memberId, IPerson person)
        {
            try
            {
                var member = _db.Members.FirstOrDefault(i => i.MemberId == memberId);
                var oldPerson = member.Person;

                oldPerson.Email = string.IsNullOrEmpty(person.Email) ? oldPerson.Email : person.Email;
                oldPerson.Mobile = string.IsNullOrEmpty(person.Mobile) ? oldPerson.Mobile : person.Mobile;
                oldPerson.WhatsApp = string.IsNullOrEmpty(person.WhatsApp) ? oldPerson.WhatsApp : person.WhatsApp;
                oldPerson.PersonName = string.IsNullOrEmpty(person.PersonName) ? oldPerson.PersonName : person.PersonName;
                oldPerson.PersonSurname = string.IsNullOrEmpty(person.PersonSurname) ? oldPerson.PersonSurname : person.PersonSurname;

                ((StockTrackerContext) _db).SaveChanges();
								_log.LogInformation((int)LoggingEvent.Create, $"Updated Member[{memberId}] Person details.");

                return member;
						}
            catch (Exception e)
            {
								_log.LogError((int)LoggingEvent.Update, e, $"An error while updating Member[{memberId}] Person details.");
                return null;
						}
        }

        IMember BlockCheck(string message)
        {
            _log.LogError((int)LoggingEvent.BadParameters, message);
            return (IMember) null;
        }
    }
}
