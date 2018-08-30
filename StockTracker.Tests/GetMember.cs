using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Interface.BusinessLogic;
using StockTracker.Interface.Context;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;
using IStockTrackerContext = StockTracker.Interface.Models.User.IStockTrackerContext;

namespace StockTracker.Test
{
	[TestClass]
    public class GetMember
    {
		private readonly Mock<IGetMember> _getMember;



		public GetMember()
	    {
		    _getMember = new Mock<IGetMember>().SetupAllProperties();
		    SetupMocks();
		}

	    private void SetupMocks()
	    {
		    _getMember.Setup(i => i.GetMemberByMemberId(It.IsAny<int>())).Returns(new Mock<IMember>().Object);
		    _getMember.Setup(i => i.GetMemberByPersonId(It.IsAny<int>())).Returns(new Mock<IMember>().Object);
	    }

	    [TestMethod]
	    public void GetMemberByMemberId_Passed1_ReturnMember()
	    {
		    var result = _getMember.Object.GetMemberByMemberId(1);

			Assert.IsInstanceOfType(result, typeof(IMember),"A Member was returned!");
	    }

		[TestMethod]
		public void GetMemberByMemberId_Passed0_ReturnNull()
		{

		}
    }
}
