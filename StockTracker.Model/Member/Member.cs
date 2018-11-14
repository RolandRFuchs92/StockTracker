using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StockTracker.Interface.Models.Member;
using StockTracker.Model.Clients;
using StockTracker.Model.Shopping;

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
		public DateTime? LastActiveDate { get; set; }

		public Person.Person Person { get; set; }
		public Client Client { get; set; }
		public MemberRole MemberRole { get; set; }

		public ICollection<ShoppingList> ShoppingLists { get; set; }
	}
}
