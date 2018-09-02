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

			_member = new GetMembers(_db);
		}

		
		[TestMethod]
		public void GetMemberByMemberId_Passed1_ReturnMember()
		{
			//Arrange
			var searchId = 1;

			//Act
			var result = _member.GetMemberByMemberId(searchId);

			//Assert
			Assert.AreEqual(searchId, result.MemberId, "Result from Db was not the same as the result.");

		}

		[TestMethod]
		public void GetMemberById_Passed0_ReturnEmpty()
		{
			//Arrange
			var searchId = 0;

			//Act
			var result = _member.GetMemberByMemberId(searchId);

			//Assert
			Assert.AreSame(null, result);
		}

	}
}
