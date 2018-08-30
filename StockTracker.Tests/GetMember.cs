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

namespace StockTracker.Test
{
	[TestClass]
    public class GetMember
    {
		private readonly IStockTrackerContext _db;



		public GetMember(IStockTrackerContext db)
		{
			_db = SetupMocks();
		}

	    private IStockTrackerContext SetupMocks()
	    {
		    var moq = new Mock<IStockTrackerContext>();

		    moq.SetupAllProperties();
			
		    return moq.Object;
	    }

	    [TestMethod]
	    public void GetMemberByMemberId_Passed1_ReturnMember()
	    {
		    var result = _db.Persons.Where(i=>i.PersonId == 1).ToList();

			
	    }

    }
}
