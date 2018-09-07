using System;

namespace StockTracker.Extensions
{
    public static class Shortcuts
    {
	    public static bool IsTrue(this Random rng)
	    {
		    return rng.Next(1) > 0;
	    }

	    public static DateTime Day(this Random rng)
	    {
			return Day(rng, 100);
	    }

	    public static DateTime Day(this Random rng, int maxRange)
	    {
		    return DateTime.Now.AddDays(-1 * rng.Next(maxRange));
	    }
    }
}
