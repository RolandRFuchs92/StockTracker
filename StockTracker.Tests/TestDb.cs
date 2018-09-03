using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockTracker.Context;
using StockTracker.Seed;

namespace StockTracker.Test
{
    public static class TestDb
    {
	    public static StockTrackerContext db { get; }

	    static TestDb()
	    {
		    var builder = new DbContextOptionsBuilder<StockTrackerContext>();
		    builder.UseInMemoryDatabase();

		    db = new StockTrackerContext(builder.Options);
		    new PopulateDb(db).Populate();
	    }

    }
}
