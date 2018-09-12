using Microsoft.EntityFrameworkCore;
using StockTracker.Context;
using StockTracker.Seed;

namespace StockTracker.Repository.Test
{
    public class TestDb
    {
	    public StockTrackerContext Db { get; }
	    private bool IsActive;

	    public TestDb()
	    {
			if(IsActive) return;

		    var builder = new DbContextOptionsBuilder<StockTrackerContext>();
		    builder.UseInMemoryDatabase();

		    Db = new PopulateDb(new StockTrackerContext(builder.Options)).Populate();
		    IsActive = true;
	    }

    }
}
