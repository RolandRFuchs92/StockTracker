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
using StockTracker.BusinessLogic.Interface.BusinessLogic;
using StockTracker.BusinessLogic.MemberLogic;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;
using StockTracker.Model;
using StockTracker.Seed;

namespace StockTracker.Test
{
	[TestClass]
	public class GetMemberTest
	{
		private readonly IGetMembers _member;
		private StockTrackerContext _db;

		public GetMemberTest()
		{
			_db = TestDb.db;
			_member = new GetMembers(_db);
		}

		
		[TestMethod]
		public void GetMemberByMemberId_Passed1_ReturnMember()
		{
			//Arrange
			var memberId = 1;

			//Act
			var result = _member.GetMemberByMemberId(memberId);

			//Assert
			Assert.AreEqual(memberId, result.MemberId, "Result from Db was not the same as the result.");

		}

		[TestMethod]
		public void GetMemberById_Passed0_ReturnNull()
		{
			//Arrange
			var memberId= 0;

			//Act
			var result = _member.GetMemberByMemberId(memberId);

			//Assert
			Assert.AreSame(null, result);
		}

		[TestMethod]
		public void GetMemberById_Passed10_ContainsAValidPersonObject()
		{
			//Arrange
			var memberId = 10;

			//Act
			var result = _member.GetMemberByMemberId(memberId);

			//Assert
			Assert.IsInstanceOfType(result.Person, typeof(IPerson));
		}
	}
}
