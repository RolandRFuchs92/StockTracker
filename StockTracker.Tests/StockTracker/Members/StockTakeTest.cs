using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;

namespace StockTracker.Test.StockTracker.Members
{
    public class StockTakeTest
    {
	    private readonly StockTrackerContext _db;

	    public StockTakeTest()
	    {
		    _db = TestDb.db;
	    }



    }
}
