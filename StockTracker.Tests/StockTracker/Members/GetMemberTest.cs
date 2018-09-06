using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Members;
using StockTracker.BusinessLogic.MemberLogic;
using StockTracker.Context;
using StockTracker.Interface.Models.User;

namespace StockTracker.Test.StockTracker.Members
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

		#region GetMemberByMemberId
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
		public void GetMemberByMemberId_Passed0_ReturnNull()
		{
			//Arrange
			var memberId= 0;

			//Act
			var result = _member.GetMemberByMemberId(memberId);

			//Assert
			Assert.AreSame(null, result);
		}

		[TestMethod]
		public void GetMemberByMemberId_Passed1000000_ShouldReturnNull()
		{
			//Arrange
			var memberId = 1000000;

			//Act
			var result = _member.GetMemberByMemberId(memberId);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void GGetMemberByMemberId_Passed10_ContainsAValidPersonObject()
		{
			//Arrange
			var memberId = 10;

			//Act
			var result = _member.GetMemberByMemberId(memberId);

			//Assert
			Assert.IsInstanceOfType(result.Person, typeof(IPerson));
		}

		[TestMethod]
		public void GetMemberByPersonId_Passed1_ShouldGetAMemberWithPersonIdOf1()
		{
			//Arrange
			var personId = 1;

			//Act
			var result = _member.GetMemberByPersonId(personId);

			//Assert
			Assert.AreEqual(personId, result.PersonId);
		}
		#endregion

		#region GetMemberByPersonId
		[TestMethod]
		public void GetMemberByPersonId_Passed0_ShouldGetNull()
		{
			//Arrange
			var personId = 0;

			//Act
			var result = _member.GetMemberByPersonId(personId);

			//Assert
			Assert.AreEqual(null, result?.Person ?? null);
		}

		[TestMethod]
		public void GetMemberByPersonId_Passed10_ShouldGetAMemberWithPersonId10()
		{
			//Arrange
			var personId = 10;

			//Act
			var result = _member.GetMemberByPersonId(personId);

			//Assert
			Assert.AreEqual(personId, result.PersonId);
		}

		[TestMethod]
		public void GetMemberByPersonId_Passed10000000_ShouldReturnNull()
		{
			//Arrange
			var personId = 10000000;

			//Act
			var result = _member.GetMemberByPersonId(personId);

			//Assert
			Assert.IsNull(result);
		}
		#endregion

		#region GetMemberByMemberRoleId
		[TestMethod]
		public void GetMembersByMemberRoleId_Passed1_ShouldGetAListOfMembers()
		{
			//Arrange
			var roleId = 1;

			//Act
			var result = _member.GetMembersByMemberRoleId(roleId);

			//Assert
			Assert.IsTrue(result.Count > 1);
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IMember));
		}

		[TestMethod]
		public void GetMembersByMemberRoleId_Passed120_ShouldReturnNull()
		{
			//Arrange
			var memberRoleId = 120;

			//Act
			var _result = _member.GetMembersByMemberRoleId(memberRoleId);

			//Assert
			Assert.IsNull(_result);
		}

		[TestMethod]
		public void GetMembersByMemberRoleId_Passed0_ShouldReturnNull()
		{
			//Arrange
			var memberRoleId = 0;

			//Act
			var result = _member.GetMembersByMemberRoleId(memberRoleId);

			//Assert
			Assert.IsNull(result);
		}
		#endregion

		#region Get
		[TestMethod]
		public void Get_PassedClientId_ShouldGetAListOfMembers()
		{
			//Arrange
			int clientId = 1;

			//Act
			var result = _member.Get(clientId);

			//Assert
			if (result != null)
			{
				Assert.IsTrue(result.Count > 0);
				Assert.IsInstanceOfType(result, typeof(List<IMember>));
			}
		}

		[TestMethod]
		public void Get_Passed0_ShouldNotThrowAndShouldReturnNull()
		{
			//Arrange
			var clientId = 0;

			//Act
			var result = _member.Get(clientId);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void Get_PassedClientIdAndRoleId_ShouldGetAListOfMembers()
		{
			//Arrange
			var clientId = 1;
			var memberRoleId = 1;

			//Act
			var result = _member.Get(clientId, memberRoleId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(List<IMember>));
			Assert.IsTrue(result.Count > 0);
		}

		[TestMethod]
		public void Get_PassedClientIdAndRoleId_ShouldNotThrow()
		{
			//Arrange
			var clientId = 0;
			var memberId = 0;

			var clientId2 = 1;
			var memberId2 = 0;

			var clientId3 = 0;
			var memberId3 = 1;

			//Act
			var result1 = _member.Get(clientId, memberId);
			var result2 = _member.Get(clientId2, memberId2);
			var result3 = _member.Get(clientId3, memberId3);

			//Assert
			Assert.IsNull(result1);
			Assert.IsNull(result2);
			Assert.IsNull(result3);
		}
		#endregion

		#region GetAllMembers

		[TestMethod]
		public void GetAllMembers_PassedInClientId_GetAListOFMember()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _member.GetAllMembers(clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(List<IMember>));
			Assert.IsTrue(result.Count > 0);
		}

		[TestMethod]
		public void GetAllMembers_PassedInvalidClientId_ReturnNullNoError()
		{
			//Arrange
			var clientId = 0;

			//Act
			var result = _member.GetAllMembers(clientId);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void GetAllMembers_PassedClientAndMemberRole_ReturnAListOfMembersInRoll()
		{
			//Arrange
			var clientId = 1;
			var memberRoleId = 1;

			//Act
			var result = _member.GetAllMembers(clientId, memberRoleId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
			Assert.IsInstanceOfType(result, typeof(List<IMember>));
			Assert.IsTrue(result.FirstOrDefault().MemberId == memberRoleId);
		}


		[TestMethod]
		public void GetAllMembers_PassedInvalidValues_ReturnNull()
		{
			//Arrange
			var clientId1 = 0;
			var memberRoleId1 = 0;

			var clientId2 = 0;
			var memberRoleId2 = 0;

			var clientId3 = 0;
			var memberRoleId3 = 0;

			//Act
			var result1 = _member.GetAllMembers(clientId1, memberRoleId1);
			var result2 = _member.GetAllMembers(clientId2, memberRoleId2);
			var result3 = _member.GetAllMembers(clientId3, memberRoleId3);

			//Assert
			Assert.IsNull(result1);
			Assert.IsNull(result2);
			Assert.IsNull(result3);
		}
		#endregion

	}
}
