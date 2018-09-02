﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StockTracker.Interface.Models.User
{
    public interface IMember 
    {
        int MemberId { get; set; }
		int? PersonId { get; set; }
		int? MemberRoleId { get; set; }
		bool IsActive { get; set; }
		DateTime LastActiveDate { get; set; }
	}
}
