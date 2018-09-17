using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Interface.Models.Stock;
using StockTracker.Repository.Interface.BusinessLogic.Stock;

namespace StockTracker.Repository.Stock
{
    public class GetStockLevel : IGetStockLevel
    {
	    private StockTrackerContext _db;

	    public GetStockLevel(StockTrackerContext db)
	    {
		    _db = db;
	    }

	    public IStockLevel Get(int stockItemId, int clientId)
	    {
		    return _db.StockLevels.FirstOrDefault(i => i.StockPar.StockItemId == stockItemId && i.StockPar.ClientId == clientId);
	    }

	    public List<IStockLevel> Get(List<int> stockItemIds, int clientId)
	    {
		    return _db.StockLevels.Where(i => stockItemIds.Contains(i.StockPar.StockItemId) && i.StockPar.ClientId == clientId).ToList<IStockLevel>();

	    }

	    public List<IStockLevel> GetByCategoryId(int categoryId, int clientId)
	    {
		    return _db.StockLevels.Where(i => i.StockPar.StockItem.StockCategoryId == categoryId && i.StockPar.ClientId == clientId)
			    .ToList<IStockLevel>();
	    }

	    public List<IStockLevel> GetByCategoryId(List<int> categoryIds, int clientId)
	    {
		    return _db.StockLevels.Where(i => categoryIds.Contains(i.StockPar.StockItem.StockCategoryId) && i.StockPar.ClientId == clientId)
			    .ToList<IStockLevel>();
	    }
    }
}
