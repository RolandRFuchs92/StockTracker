using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Repository.Interface.BusinessLogic.Stock;

namespace StockTracker.Repository.Stock
{
    public class DisableStock: IDisableStock
    {
	    private StockTrackerContext _db;

	    public DisableStock(StockTrackerContext db)
	    {
		    _db = new StockTrackerContext();
	    }

	    public bool Disable(int stockItemId, int clientId)
	    {
		    try
		    {
			    var item = _db.StockPars.FirstOrDefault(i => i.ClientId == clientId && i.StockItemId == stockItemId);
			    item.IsActive = false;
			    _db.SaveChanges();

			    return true;
		    }
		    catch (Exception e)
		    {
			    return false;
		    }
	    }

	    public bool Disable(List<int> stockItemId, int clientId)
	    {
		    try
		    {
			    var stockList = _db.StockPars.Where(i => stockItemId.Contains(i.StockItemId) && i.ClientId == clientId).ToList();
				foreach (var stockPar in stockList)
				{
					stockPar.IsActive = false;
				}

			    _db.SaveChanges();

			    return true;
		    }
		    catch (Exception e)
		    {
			    return false;
		    }

	    }

	    public bool DisableByCategory(int categoryId, int clientId)
	    {
		    try
		    {
			    var stockList = _db.StockPars.Where(i => i.StockItem.StockCategoryId == categoryId && i.ClientId == clientId).ToList();

				foreach (var stockItem in stockList)
				{
					stockItem.IsActive = false;
				}

			    _db.SaveChanges();

			    return true;
		    }
		    catch (Exception e)
		    {
			    return false;
		    }
	    }

	    public bool DisableByCategory(List<int> categoryIds, int clientId)
	    {
		    try
		    {
			    var stockList = _db.StockPars.Where(i => categoryIds.Contains(i.StockItem.StockCategoryId) && i.ClientId == clientId);

				foreach (var stockPar in stockList)
				{
					stockPar.IsActive = false;
				}

			    _db.SaveChanges();

			    return true;
		    }
		    catch (Exception e)
		    {
			    return false;
		    }
	    }

	    public bool DisableAll(int clientId)
	    {
		    try
		    {
			    var stockList = _db.StockPars.Where(i => i.ClientId == clientId).ToList();

				foreach (var stockPar in stockList)
				{
					stockPar.IsActive = false;
				}

			    _db.SaveChanges();

			    return true;
		    }
		    catch (Exception e)
		    {
			    return false;
		    }
	    }

	    public bool DisableAll(List<int> clientIds)
	    {
		    try
		    {
			    var stockList = _db.StockPars.Where(i => clientIds.Contains(i.ClientId));

			    foreach (var stockPar in stockList)
			    {
				    stockPar.IsActive = false;
			    }
			    _db.SaveChanges();

			    return true;
		    }
		    catch (Exception e)
		    {
				return false;
		    }
	    }
    }
}
