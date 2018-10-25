using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;
using StockTracker.Model.User;
using StockTracker.Seed.Client;
using StockTracker.Seed.Member;
using StockTracker.Seed.Settings;

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
