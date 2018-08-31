using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.User;

namespace StockTracker.Model
{
	public class Member: IMember

	{
		public int MemberId { get; set; }
		public int PersonId { get; set; }
		public int MemberRoleId { get; set; }
		public int IsActive { get; set; }
		public DateTime LastActiveDate { get; set; }
		public IPerson Person { get; set; }
		public IMemberRole MemberRole { get; set; }
	}
}
