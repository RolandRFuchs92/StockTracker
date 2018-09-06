﻿using System.Collections.Generic;
using StockTracker.Model.User;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Members
{
    public interface IGetMembers
    {
	    Member GetMemberByMemberId(int memberId);
	    Member GetMemberByPersonId(int personId);
	    List<Member> GetMembersByMemberRoleId(int memberRoleId);
	    List<Member> GetMembers(int clientId);
	    List<Member> GetMembers(int clientId, int memberRoleId);
	    List<Member> GetAllMembers(int clientId);
	    List<Member> GetAllMembers(int clientId, int memberRoleId);
    }
}