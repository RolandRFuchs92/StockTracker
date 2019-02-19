using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Supplier;
using StockTracker.Model.Supplier;
using StockTracker.Repository.Enums;
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

		public ISupplierType Add(ISupplierType supplierType)
		{
			try
			{
				if (!IsValidSupplierType(supplierType))
					return null;

				_db.SupplierTypes.Add((SupplierType)supplierType);
				_db.SaveChanges();

				LogInformation(LoggingEvent.Create, $"Added SupplierType[{supplierType.SupplierTypeName}]");

				return supplierType;
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"There was an error Adding[{supplierType.SupplierTypeName}]", e);
				return null;
			}
		}


		public ISupplierType Edit(ISupplierType supplierType)
		{
			try
			{
				if (!IsValidSupplierType(supplierType, false))
					return null;

				var model = _db.SupplierTypes.FirstOrDefault(i => i.SupplierTypeId == supplierType.SupplierTypeId);

				if (model == null)
				{
					LogError(LoggingEvent.Error, $"SupplierType[{supplierType.SupplierTypeId}] does not exists.");
					return null;
				}

				model.SupplierTypeName = supplierType.SupplierTypeName;
				_db.SaveChanges();

				LogInformation(LoggingEvent.Update, $"Edited SupplierType[{supplierType.SupplierTypeId}]");

				return supplierType;
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"There was an error editing SupplierType[{supplierType.SupplierTypeName}]", e);
				return null;
			}
		}

		public bool IsValid(int supplierTypeId)
		{
			return _db.SupplierTypes.Any(i => i.SupplierTypeId == supplierTypeId);
		}

		public List<ISupplierType> List()
		{
			try
			{
				return _db.SupplierTypes.ToList<ISupplierType>();
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"There was an error while trying to list SupplierTypes.", e);
				return null;
			}
		}

		private bool IsValidSupplierType(ISupplierType supplierType, bool isAdd = true)
		{
			var isEmptyName = string.IsNullOrEmpty(supplierType.SupplierTypeName);
			var idPresent = supplierType.SupplierTypeId != 0;

			if (isAdd && idPresent || isEmptyName)
			{
				var message = idPresent
					? "Cannot add a preassigned entity."
					: $"SupplierType.Name[{supplierType.SupplierTypeName}] provided was empty.";
				LogError(LoggingEvent.Error, message);
				return false;
			}

			var exists = _db.SupplierTypes.Any(i => i.SupplierTypeName == supplierType.SupplierTypeName);
			if (exists)
			{
				LogError(LoggingEvent.Error, $"SupplierType[{supplierType.SupplierTypeName}] already exists.");
				return false;
			}

			return true;
		}

	}
}
