using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.User;

namespace StockTracker.Seed.Member
{
    public class GenerateFakeMembers
    {
	    private readonly int _memberRoleCount;

	    public GenerateFakeMembers()
	    {
			_memberRoleCount = new GenerateMemberRoles().GenerateMemberRole().Count;
	    }

		public List<IMember> SetupSeedMembers(List<IPerson> people)
		{
			var members = new List<IMember>();
			var rnd = new Random();

			foreach (var person in people)
			{
				members.Add(new Model.Member
				{
					PersonId = person.PersonId,
					IsActive = (rnd.Next(0, 1) > 0),
					MemberRoleId = rnd.Next(1, _memberRoleCount),
					LastActiveDate = DateTime.Now
				});
			}

			return members;
		}
	}
}
