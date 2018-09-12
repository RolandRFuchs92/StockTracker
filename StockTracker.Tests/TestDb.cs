using Microsoft.EntityFrameworkCore;
using StockTracker.Context;
using StockTracker.Seed;

namespace StockTracker.Repository.Test
{
    public class TestDb
    {
	    public StockTrackerContext Db { get; }
	    public TestDb()
	    {
		    var builder = new DbContextOptionsBuilder<StockTrackerContext>();
		    builder.UseInMemoryDatabase();

		    Db = new StockTrackerContext(builder.Options);
		    new PopulateDb(Db).Populate();
	    }

    }
}
