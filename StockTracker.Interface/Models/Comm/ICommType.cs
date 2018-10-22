using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Comm
{
    public interface ICommType
    {
	    int CommTypeId { get; set; }
	    string CommName { get; set; }
    }
}
