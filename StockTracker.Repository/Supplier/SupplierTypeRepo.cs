using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Supplier;
using StockTracker.Repository.Interface.Supplier;
using StockTracker.Repository.Util;

namespace StockTracker.Repository.Supplier
{
    public class SupplierTypeRepo : Logging<SupplierTypeRepo>, ISupplierTypeRepo
    {
	    private readonly StockTrackerContext _db;

	    public SupplierTypeRepo(IStockTrackerContext db, ILoggerAdapter<SupplierTypeRepo> log) : base(log)
	    {
		    _db = (StockTrackerContext)db;
	    }

	    public ISupplierType Add(ISupplierType supplier)
	    {
		    throw new NotImplementedException();
	    }

	    public ISupplierType Edit(ISupplierType supplier)
	    {
		    throw new NotImplementedException();
	    }

	    public bool IsValid(int supplierTypeId)
	    {
		    throw new NotImplementedException();
	    }

	    public List<ISupplierType> List()
	    {
		    throw new NotImplementedException();
	    }
    }
}
