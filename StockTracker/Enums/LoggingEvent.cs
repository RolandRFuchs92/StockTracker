using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Repository.Enums
{
    public enum LoggingEvent
    {
        Create = 1000,
        Update = 1001,
        First = 1002,
        List = 1003,
        Delete = 1004,
        Insert = 1005,

        BadParameters = 2000
    }
}
