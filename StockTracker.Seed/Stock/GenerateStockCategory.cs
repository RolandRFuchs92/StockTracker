using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Model.Stock;

namespace StockTracker.Seed.Stock
{
    public class GenerateStockCategory
    {
	    public List<StockCategory> Get()
	    {
			return new List<StockCategory>
			{
				new StockCategory { 1, "Food", null, 1 },
				new StockCategory { 1, "Drink", null, 1 },
				new StockCategory { 1, "Desert", null, 1 }
			};
	    }
    }
}
