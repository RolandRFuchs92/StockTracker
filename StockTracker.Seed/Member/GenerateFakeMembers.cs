using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.User;
using StockTracker.Model;
using StockTracker.Model.User;

namespace StockTracker.Seed.Member
{
    public class GenerateFakeMembers
    {
	    private readonly int _memberRoleCount;

	    public GenerateFakeMembers()
	    {
			_memberRoleCount = new GenerateMemberRoles().GenerateMemberRole().Count();
	    }

		public List<Model.User.Member> SetupSeedMembers(List<Person> people)
		{
			var members = new List<Model.User.Member>();
			var rnd = new Random();

			foreach (var person in people)
			{
				members.Add(new Model.User.Member
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
