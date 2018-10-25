using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.ClientStock;
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

	    public List<ClientStockLevel> GetStockLevels(List<ClientStockItem> clientStockLevel)
	    {
		    return GenerateStockLevels(clientStockLevel);
	    }

	    private List<ClientStockLevel> GenerateStockLevels(List<ClientStockItem> ClientStockItem)
	    {
		    var stockLevels = new List<ClientStockLevel>();
		    foreach (var stock in ClientStockItem)
		    {
			    stockLevels.Add(new ClientStockLevel
				{
					CreatedOn = DateTime.Now,
					Quantity = _rng.Next(1,10),
					IsActive = true,
					ClientStockItemId = stock.ClientStockItemId
			    });
		    }
			stockLevels.AddRange(GenerateGenericStocks());
		    return stockLevels;
	    }

	    private List<StockLevel> GenerateGenericStocks()
	    {
		    return new List<StockLevel>
		    {
			    new StockLevel { IsActive = true, DateChecked =  DateTime.Now, Quantity = 100, StockParId = 1 },
			    new StockLevel { IsActive = true, DateChecked =  DateTime.Now, Quantity = 100, StockParId = 1 },
			    new StockLevel { IsActive = true, DateChecked =  DateTime.Now, Quantity = 100, StockParId = 1 },
			    new StockLevel { IsActive = true, DateChecked =  DateTime.Now, Quantity = 100, StockParId = 1 }
			};
	    }
    }
}
