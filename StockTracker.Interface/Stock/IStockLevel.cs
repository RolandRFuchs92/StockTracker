using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface
{
    public interface IStockLevel
    {
        int StockLevelId { get; set; }
		int StockId { get; set; }
		int Quantity { get; set; }
		DateTime DateChecked { get; set; }
		int MemberId { get; set; }
    }
}
