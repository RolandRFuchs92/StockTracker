using StockTracker.Adapter.Interface.Logger;
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
				public SupplierRepo(ILoggerAdapter<SupplierRepo> log) : base(log)
				{
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
