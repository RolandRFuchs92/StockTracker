using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StockTracker.Interface.Models.User;

namespace StockTracker.Model
{
	public class Member: IMember
	{
		[Key]
		public int MemberId { get; set; }
		public int? PersonId { get; set; }
		public int? MemberRoleId { get; set; }
		public bool IsActive { get; set; }
		public DateTime LastActiveDate { get; set; }

		[ForeignKey("PersonId")]
		public Person Person { get; set; }
		[ForeignKey("MemberRoleId")]
		public MemberRole MemberRole { get; set; }
	}
}
