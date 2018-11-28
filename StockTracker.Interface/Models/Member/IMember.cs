using System;
using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.Member
{
    public interface IMember 
    {
        int MemberId { get; set; }
		int PersonId { get; set; }
		int ClientId { get; set; }
		int MemberRoleId { get; set; }
		bool IsActive { get; set; }
		DateTime? LastActiveDate { get; set; }
	}
}
