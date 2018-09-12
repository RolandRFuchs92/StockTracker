using Microsoft.EntityFrameworkCore;
using StockTracker.Context;
using StockTracker.Seed;

namespace StockTracker.Repository.Test
{
    public class TestDb
    {
	    public StockTrackerContext db { get; }
		public static bool isActive { get; set; }

	    public TestDb()
	    {
			if (isActive) return;

		    var builder = new DbContextOptionsBuilder<StockTrackerContext>();
		    builder.UseInMemoryDatabase();

		    db = new StockTrackerContext(builder.Options);
		    new PopulateDb(db).Populate();
			isActive = true;
	    }

    }
}
