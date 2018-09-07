using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Extensions
{
    public static class TimeExtensions
    {
	    public static DateTime Time(this DateTime date, int hour, int minute, int second)
	    {
			return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
	    }

	    public static DateTime Time(this DateTime date, int hour, int minute)
	    {
		    return Time(date, hour, minute, 0);
	    }

	    public static DateTime Time(this DateTime date, int hour)
	    {
		    return Time(date, hour, 0);
	    }
    }
}
