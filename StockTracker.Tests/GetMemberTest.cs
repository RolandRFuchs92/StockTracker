using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.BusinessLogic.MemberLogic;
using StockTracker.Context;
using StockTracker.Interface.BusinessLogic;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;
using StockTracker.Model;

namespace StockTracker.Test
{
	[TestClass]
	public class GetMemberTest
	{
		private readonly IGetMember _member;
		private StockTrackerContext _db;


		public GetMemberTest()
		{
			var builder = new DbContextOptionsBuilder<StockTrackerContext>();
			builder.UseInMemoryDatabase();

			_db = new StockTrackerContext(builder.Options);
			var member = DefaultMember();
			_db.Members.AddRange(SetupSeedMembers());
			_db.SaveChanges();

			_member = new GetMembers(_db);
		}

		private Member DefaultMember()
		{
			return new Member()
			{
				IsActive = false,
				PersonId = 1,
				LastActiveDate = DateTime.Now,
				MemberRoleId = 1,
				MemberId = 1
			};
		}

		private List<Member> SetupSeedMembers()
		{
			var members = new List<Member>();
			var rnd = new Random();

			for (var inc = 1; inc < 100; inc++)
			{
				members.Add(new Member
				{ 
					PersonId = inc,
					IsActive = (rnd.Next(0,1) > 0),
					MemberRoleId = rnd.Next(1,5),
					LastActiveDate = DateTime.Now,
					MemberId = inc
				});
			}
			return members;
		}


		[TestMethod]
		public void GetMemberByMemberId_Passed1_ReturnMember()
		{
			//Arrange

			//Act
			var result = _member.GetMemberByMemberId(1);

			//Assert
			Assert.AreEqual(DefaultMember().PersonId, result.PersonId, "Result from Db was not the same as the result.");

		}

		[TestMethod]
		public void GetMemberById_Passed0_ReturnEmpty()
		{
			//Arrange

			//Act
			var result = _member.GetMemberByMemberId(0);

			//Assert
			Assert.AreSame(null, result);
		}

	}
}
