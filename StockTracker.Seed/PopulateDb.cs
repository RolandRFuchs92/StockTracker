using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context.Interface;

namespace StockTracker.Seed
{
    public class PopulateDb
    {
	    private readonly IStockTrackerContext _db
		    ;

	    public PopulateDb(IStockTrackerContext db)
	    {
		    _db = db;
	    }

	    public bool Populate()
	    {



		    return false;
	    }

	    public void PopulateLeaves()
	    {
		    var memberRoles = new GenerateMemberRoles().GenerateMemberRole();
	    }
    }
}
