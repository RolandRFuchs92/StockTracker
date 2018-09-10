using Microsoft.EntityFrameworkCore;
using StockTracker.Context;
using StockTracker.Seed;

namespace StockTracker.Repository.Test
{
    public static class TestDb
    {
	    public static StockTrackerContext db { get; }
		public static bool isActive { get; set; }

	    static TestDb()
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
