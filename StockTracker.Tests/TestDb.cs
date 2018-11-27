﻿using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using StockTracker.Context;
using StockTracker.Seed;

namespace StockTracker.Repository.Test
{
    public class TestDb
    {
	    public StockTrackerContext Db { get; private set; }
	    private bool IsActive;

	    public TestDb()
	    {
		    ResetDb();
	    }

	    private void ResetDb()
	    {
		    if (IsActive) return;

		    var builder = new DbContextOptionsBuilder<StockTrackerContext>();
		    builder.UseInMemoryDatabase();
	        builder.EnableSensitiveDataLogging();

            Db = new PopulateDb(new StockTrackerContext(builder.Options)).Populate();
		    IsActive = true;
		}
    }
}
