using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStockCategory
    {
		/*Is it meat, beer, liquor, sweet, hot drink, soda, veggie, fruit*/
        int StockCategoryId { get; set; }
		string StockCategoryName { get; set; }
    }
}
