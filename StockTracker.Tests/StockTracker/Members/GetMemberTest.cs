using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Member;
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
	}
}
