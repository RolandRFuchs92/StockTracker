using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Interface.BusinessLogic;
using StockTracker.Interface.Context;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;
using StockTracker.Model;

namespace StockTracker.Test
{
	[TestClass]
    public class GetMember
    {
	    private readonly Mock<IGetMember> _member;


		public GetMember()
		{
			_member = new Mock<IGetMember>();
		}


	    [TestMethod]
	    public void GetMemberByMemberId_Passed1_ReturnMember()
	    {
			//Arrange
		    _member.Setup(i => i.GetMemberByMemberId(It.IsAny<int>())).Returns(new Member{ IsActive = 1, PersonId = 1, LastActiveDate = DateTime.Now,MemberRoleId = 1,MemberId = 1});

			//Act
		    var result = _member.Object.GetMemberByMemberId(1);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IMember), "Needs to return a new Member.");
			Assert.IsNotNull(result);
	    }

		[TestMethod]
		public void GetMemberById_Passed0_ReturnEmpty()
		{
			//Arrange
			_member.Setup(i => i.GetMemberByMemberId(It.Is<int>(b => b == 0))).Returns(new Member());

			//Act
			var result = _member.Object.GetMemberByMemberId(0);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IMember));
		}

    }
}
