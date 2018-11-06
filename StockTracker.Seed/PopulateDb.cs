
using StockTracker.Context;


namespace StockTracker.Seed
{
	public class PopulateDb
	{
		private readonly StockTrackerContext _db;

		public PopulateDb(StockTrackerContext db)
		{
			_db = db;
		}

		public StockTrackerContext Populate()
		{
			return _db;
		}

	}
}
