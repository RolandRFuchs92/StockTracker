using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;

namespace StockTracker.Seed.Stock
{
    public class GenerateStockLevel
    {
	    private int _memberMaxCount;
	    private Random _rng;

	    public GenerateStockLevel(int memberCount)
	    {
		    _rng = new Random();
		    _memberMaxCount = memberCount;
	    }

	    public List<StockLevel> GetStockLevels(List<StockItem> stocks)
	    {
		    return GenerateStockLevels(stocks);
	    }

	    private List<StockLevel> GenerateStockLevels(List<StockItem> stocks)
	    {
		    var stockLevels = new List<StockLevel>();
		    foreach (var stock in stocks)
		    {
			    stockLevels.Add(new StockLevel
			    {
					DateChecked = DateTime.Now,
					MemberId = _rng.Next(1,_memberMaxCount),
					Quantity = _rng.Next(1,10),
					StockItemId = stock.StockItemId,
					ClientId = _rng.Next(1,5)
			    });
		    }
			stockLevels.AddRange(GenerateGenericStocks());
		    return stockLevels;
	    }

	    private List<StockLevel> GenerateGenericStocks()
	    {
		    return new List<StockLevel>
		    {
			    new StockLevel {ClientId = 1, DateChecked = DateTime.Now, MemberId = 1, Quantity = 100},
			    new StockLevel {ClientId = 1, DateChecked = DateTime.Now, MemberId = 1, Quantity = 100},
			    new StockLevel {ClientId = 1, DateChecked = DateTime.Now, MemberId = 1, Quantity = 1},
			    new StockLevel {ClientId = 1, DateChecked = DateTime.Now, MemberId = 1, Quantity = 1}
			};
	    }
    }
}
