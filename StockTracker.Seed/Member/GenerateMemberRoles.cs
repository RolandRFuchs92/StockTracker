﻿using System;
using System.Collections.Generic;
using StockTracker.Interface.Models.User;
using StockTracker.Model;

namespace StockTracker.Seed
{
    public class GenerateMemberRoles
    {
	    public List<MemberRole> GenerateMemberRole()
	    {
		    return new List<MemberRole>
		    {
				new MemberRole{ MemberRoleId = 1, MemberRoleName = "Manager" },
				new MemberRole{ MemberRoleId = 2, MemberRoleName = "Waiter" },
				new MemberRole{ MemberRoleId = 3, MemberRoleName = "Chef" }
		    };
	    }
    }
}
