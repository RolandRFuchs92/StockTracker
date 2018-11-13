using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StockTracker.Interface.Models.Member;
using StockTracker.Model.Clients;

namespace StockTracker.Model.Member
{
	public class Member: IMember
	{
		[Key]
		public int MemberId { get; set; }
		public int PersonId { get; set; }
		public int ClientId { get; set; }
		public int MemberRoleId { get; set; }
		public bool IsActive { get; set; }
		public DateTime LastActiveDate { get; set; }

		[ForeignKey("PersonId")]
		public virtual Person.Person Person { get; set; }

		[ForeignKey("ClientId")]
		public virtual Client Client { get; set; }

		[ForeignKey("MemberRoleId")]
		public virtual MemberRole MemberRole { get; set; }
	}
}
