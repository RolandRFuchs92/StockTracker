using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Model;
using StockTracker.Model.Person;

namespace StockTracker.Seed.Member
{
    public class GenerateFakeMembers
    {
	    private readonly int _memberRoleCount;
	    private const int _maxClients = 5;

	    public GenerateFakeMembers()
	    {
			_memberRoleCount = new GenerateMemberRoles().GenerateMemberRole().Count();
	    }

		public List<Model.Members.Member> SetupSeedMembers(List<Person> people)
		{
			var members = new List<Model.Members.Member>();
			var rnd = new Random();

			members.Add(AddUseCaseMember());
			foreach (var person in people)
			{
				members.Add(new Model.Members.Member
				{
					PersonId = person.PersonId,
					IsActive = true,
					MemberRoleId = rnd.Next(1, _memberRoleCount),
					LastActiveDate = DateTime.Now,
					ClientId = rnd.Next(1, _maxClients)
				});
			}

			return members;
		}

	    public Model.Members.Member AddUseCaseMember()
	    {
		    return new Model.Members.Member
		    {
				ClientId = 1,
				IsActive = false,
				MemberRoleId = 1,
				PersonId =  1,
				LastActiveDate =  DateTime.Now
		    };
	    }
	}
}
