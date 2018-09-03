using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;

namespace StockTracker.Seed.Stock
{
    public class GenerateStockItems
    {
	    private readonly List<string> _stockName;
	    private readonly Random _rng;

	    public GenerateStockItems()
	    {
			_stockName = new List<string>();
		    _rng = new Random();
		}

	    public List<StockItem> GetStocks()
	    {
		    ApplyStocks();
			return GenerateStockList();
	    }

	    private List<StockItem> GenerateStockList()
	    {
		    var stocks = new List<StockItem>();

			foreach(var stockItem in _stockName)
		    {
				stocks.Add(new StockItem()
				{
					IsActive = _rng.Next(0,1) > 0,
					DateCreated =  DateTime.Now,
					StockItemName = stockItem,
					StockItemPrice = _rng.Next(1,250)
				});
		    }

		    return stocks;
	    }

	    private void ApplyStocks()
	    {
			_stockName.Add("Eisbein");
			_stockName.Add("Chicken Fillet");
			_stockName.Add("Ox Tail");
			_stockName.Add("Chicken Nuggets");
			_stockName.Add("Chicken");
			_stockName.Add("Ham");
			_stockName.Add("Eggs");
			_stockName.Add("Lamb Shank");
			_stockName.Add("Schloop - Belgium Chocolate");
			_stockName.Add("Schloop - Chai Latte");
			_stockName.Add("Coffee - Dark roast");
			_stockName.Add("Coffee - Decaffenated");
			_stockName.Add("Milk");
			_stockName.Add("Hot Chocolate");
			_stockName.Add("Five Roses");
			_stockName.Add("Ice Cream");
			_stockName.Add("Potatos");
			_stockName.Add("Pears");
			_stockName.Add("Apples");
			_stockName.Add("Bread - Brown");
			_stockName.Add("Bread - White");
			_stockName.Add("French Loaf");
			_stockName.Add("Carrots");
			_stockName.Add("Beans");
			_stockName.Add("Sugar");
			_stockName.Add("Black Beans");
			_stockName.Add("Chick Peas");
			_stockName.Add("Onions");
			_stockName.Add("Cherry Tomatos");
			_stockName.Add("Fish Fingers");
			_stockName.Add("Windhoek - Lager");
			_stockName.Add("Windhoek - Light");
			_stockName.Add("Windhoek - Draft");
			_stockName.Add("Castle - Lager");
			_stockName.Add("Castle - Lite");
			_stockName.Add("Castle - Milk Stout");
			_stockName.Add("Black Label");
			_stockName.Add("Coke");
			_stockName.Add("Coke Life");
			_stockName.Add("Fanta Grape");
			_stockName.Add("Fanta Orange");
	    }
    }
}
