using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Suppliers;
using StockTracker.Repository.Interface.Suppliers;
using StockTracker.Repository.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Repository.Suppliers
{
		public class SupplierRepo : Logging<SupplierRepo>, ISupplierRepo
		{
				private readonly IStockTrackerContext _db;

				public SupplierRepo(IStockTrackerContext db ,ILoggerAdapter<SupplierRepo> log) : base(log)
				{
						_db = db;
				}

				public ISupplier Add(ISupplier supplier)
				{
						throw new NotImplementedException();
				}

				public bool Delete(int supplierId)
				{
						throw new NotImplementedException();
				}

				public ISupplier Edit(ISupplier supplier)
				{
						throw new NotImplementedException();
				}

				public ISupplier Get(int supplierId)
				{
						throw new NotImplementedException();
				}

				public List<ISupplier> List()
				{
						throw new NotImplementedException();
				}

				public List<ISupplier> ListSuppliersByType(int supplierType)
				{
						throw new NotImplementedException();
				}
		}
}
