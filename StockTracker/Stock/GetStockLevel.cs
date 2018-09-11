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
		    return _db.StockLevels.FirstOrDefault(i => i.StockItemId == stockItemId && i.ClientId == clientId);
	    }

	    public List<IStockLevel> Get(List<int> stockItemIds, int clientId)
	    {
		    return _db.StockLevels.Where(i => stockItemIds.Contains(i.StockItemId) && i.ClientId == clientId).ToList<IStockLevel>();

	    }

	    public List<IStockLevel> GetByCategoryId(int categoryId, int clientId)
	    {
		    return _db.StockLevels.Where(i => i.StockItem.StockCategoryId == categoryId && i.ClientId == clientId)
			    .ToList<IStockLevel>();
	    }

	    public List<IStockLevel> GetByCategoryId(List<int> categoryIds, int clientId)
	    {
		    return _db.StockLevels.Where(i => categoryIds.Contains(i.StockItem.StockCategoryId) && i.ClientId == clientId)
			    .ToList<IStockLevel>();
	    }
    }
}
