using StockTracker.Context.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.BuisnessLogic.Client
{
    public class AddClients
    {
	    private readonly IStockTrackerContext _db;

	    public AddClients(IStockTrackerContext db)
		{
			_db = db;
		}
	}
}
