using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface
{
    public interface IStock
    {
	    int StockId { get; set; }
	    string StockName { get; set; }
		float StockPrice { get; set; }
		DateTime DateCreated { get; set; }
		bool IsActive { get; set; }
    }
}
