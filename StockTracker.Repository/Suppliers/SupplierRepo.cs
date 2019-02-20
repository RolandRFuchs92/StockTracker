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
using StockTracker.Context;
using StockTracker.Model.Suppliers;
using StockTracker.Repository.Enums;

namespace StockTracker.Repository.Suppliers
{
	public class SupplierRepo : Logging<SupplierRepo>, ISupplierRepo
	{
		private readonly StockTrackerContext _db;
		private ModelBinder _binder;
		private ISupplierTypeRepo _supplierTypeRepo;
		
		public SupplierRepo(IStockTrackerContext db, ILoggerAdapter<SupplierRepo> log) : base(log)
		{
			_db = (StockTrackerContext)db;
			_binder = new ModelBinder();
		}

		public ISupplier Add(ISupplier supplier)
		{
			try
			{
				if (!IsValidSupplierModel(supplier)) return null;

				var model = _binder.Bind(new Supplier(), (Supplier)supplier);

				_db.Suppliers.Add(model);
				_db.SaveChanges();

				LogInformation(LoggingEvent.Create, $"Successfully added new Supplier[{model.SupplierId}]");

				return model;
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"There was an error trying to add Supplier[{supplier.SupplierName}]", e);
				return null;
			}
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

		bool IsValidSupplierModel(ISupplier supplier, bool isEdit = false)
		{
			if (string.IsNullOrEmpty(supplier.SupplierName))
			{
				LogError(LoggingEvent.Error, "The Supplier Name field was empty.");
				return false;
			}

			if (string.IsNullOrEmpty(supplier.Email) && string.IsNullOrEmpty(supplier.ContactNumber))
			{
				LogError(LoggingEvent.Error, "The Contact Number and Email Address fields were empty.");
				return false;
			}

			if (!isEdit && supplier.SupplierId != 0)
			{
				LogError(LoggingEvent.Error, "SupplierId has to be 0 in order to add a new Supplier.");
				return false;
			}

			if (isEdit && !_db.Suppliers.Any(i => i.SupplierId == supplier.SupplierId))
			{
				LogError(LoggingEvent.Error, "A valid SupplierId has to be passed in order to edit the supplier.");
				return false;
			}

			if (!_db.SupplierTypes.Any(i => i.SupplierTypeId == supplier.SupplierTypeId))
			{
				LogError(LoggingEvent.Error, $"Invalid SupplierTypeId[{supplier.SupplierTypeId}] was passed.");
				return false;
			}

			var supplierExistsInDb = _db.Suppliers.Any(i => i.SupplierName == supplier.SupplierName);
			if (supplierExistsInDb)
			{
				LogError(LoggingEvent.Error, $"The Supplier Name {supplier.SupplierName} already exists.");
				return false;
			}

			return true;
		}
	}
}
