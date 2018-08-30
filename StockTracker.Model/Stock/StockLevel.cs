using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Model.Stock
{
    public class StockLevel: IStockLevel
    {
	    public int StockLevelId { get; set; }
	    public int StockId { get; set; }
	    public int Quantity { get; set; }
	    public DateTime DateChecked { get; set; }
	    public int MemberId { get; set; }
    }
}
