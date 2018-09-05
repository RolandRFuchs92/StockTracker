﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StockTracker.Interface.Models.User;

namespace StockTracker.Model.User
{
	public class Member: IMember
	{
		[Key]
		public int MemberId { get; set; }
		public int PersonId { get; set; }
		public int MemberRoleId { get; set; }
		public bool IsActive { get; set; }
		public DateTime LastActiveDate { get; set; }

		[ForeignKey("PersonId")]
		public virtual Person Person { get; set; }
		[ForeignKey("MemberRoleId")]
		public virtual MemberRole MemberRole { get; set; }
	}
}
