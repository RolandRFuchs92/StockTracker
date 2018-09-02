using System;
using System.Collections.Generic;
using System.Linq;
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
using StockTracker.Interface.Context;
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
			_db.Members.Add(member);

			//_member = new GetMembers(_db);
		}

		private Member DefaultMember()
		{
			return new Member()
			{
				IsActive = false,
				PersonId = 1,
				LastActiveDate = DateTime.Now,
				MemberRoleId = 1,
				MemberId = 1,
				//MemberRole = new MemberRole { MemberRoleId = 1,MemberRoleName = "Camel"},
				//Person = new Person { PersonId = 1,Mobile = "1234567890",Email = "1@2.3",PersonSurname ="Surname",WhatsApp = "1234567890",PersonName = "Name"}
			};
		}


		[TestMethod]
		public void GetMemberByMemberId_Passed1_ReturnMember()
		{
			//Arrange
			var getMembers = new GetMembers(_db);

			//Act
			var result = _member.GetMemberByMemberId(1);

			//Assert
			Assert.AreSame(DefaultMember(), result);

		}

		[TestMethod]
		public void GetMemberById_Passed0_ReturnEmpty()
		{
			//Arrange
			//var getMembers = new GetMembers(_db);

			//Act
			var result = _member.GetMemberByMemberId(0);

			//Assert
			Assert.AreSame(result, new Member());
		}

	}
}
