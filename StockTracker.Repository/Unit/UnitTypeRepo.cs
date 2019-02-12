using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Unit;
using StockTracker.Model.Unit;
using StockTracker.Repository.Enums;
using StockTracker.Repository.Interface.Unit;
using StockTracker.Repository.Util;

namespace StockTracker.Repository.Unit
{
	public class UnitTypeRepo : Logging<UnitTypeRepo>, IUnitTypeRepo
	{
		private StockTrackerContext _db;

		public UnitTypeRepo(IStockTrackerContext db, ILoggerAdapter<UnitTypeRepo> log) : base(log)
		{
			_db = (StockTrackerContext)db;
		}

		public IUnitType Add(string name, string symbol)
		{
			try
			{
				var isOldUnit = _db.UnitTypes.Any(i => i.Name == name && i.Symbol == symbol);
				var nameOrSymbolEmpty = string.IsNullOrEmpty(name) || string.IsNullOrEmpty(symbol);
				if (isOldUnit || nameOrSymbolEmpty)
				{
					LogError(LoggingEvent.Error, $"Cannot add Name[{name}] or Symbol[{symbol}] as it already exists.");
					return null;
				}

				var newUnit = new UnitType
				{
					Name = name,
					Symbol = symbol
				};

				_db.UnitTypes.Add(newUnit);
				_db.SaveChanges();

				LogInformation(LoggingEvent.Create, $"Added new UnitType[{newUnit.UnitTypeId}]");

				return newUnit;
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, "", e);
				return null;
			}
		}

		public IUnitType Edit(IUnitType unitType)
		{
			try
			{
				if (UnitTypeCheck(unitType) == null)
					return null;

				var viewModel = _db.UnitTypes.FirstOrDefault(i => i.UnitTypeId == unitType.UnitTypeId);

				new ModelBinder().Bind(viewModel, unitType);
				_db.SaveChanges();

				LogInformation(LoggingEvent.Update, $"Edited UnitType[{unitType.UnitTypeId}]");

				return unitType;
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"Error Editing UnitType[{unitType.UnitTypeId}]", e);
				return null;
			}
		}

		public List<IUnitType> List()
		{
			try
			{
				return _db.UnitTypes.ToList<IUnitType>();
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"Error getting the UnitType list.", e);
				return null;
			}
		}

		public bool IsValid(int unitTypeId)
		{
			try
			{
				return _db.UnitTypes.Any(i => i.UnitTypeId == unitTypeId);
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"Error checking if UnitType[{unitTypeId}] is valid.", e);
				return false;
			}
		}

		UnitType UnitTypeCheck(string name, string symbol)
		{
			var unitType = new UnitType
			{
				Name = name,
				Symbol = symbol
			};

			return UnitTypeCheck(unitType);
		}

		UnitType UnitTypeCheck(IUnitType unitType)
		{
			if (unitType.UnitTypeId == 0 || !_db.UnitTypes.Any(i => i.UnitTypeId == unitType.UnitTypeId))
			{
				LogError(LoggingEvent.Error, $"Tried to edit UnitType[{unitType.UnitTypeId}] but was not found.");
				return null;
			}

			if (string.IsNullOrEmpty(unitType.Name))
			{
				LogError(LoggingEvent.Error, $"The name value was empty.");
				return null;
			}

			if (string.IsNullOrEmpty(unitType.Symbol))
			{
				LogError(LoggingEvent.Error, $"The symbol value was empty.");
				return null;
			}

			return new UnitType
			{
				Name = unitType.Name,
				Symbol = unitType.Symbol,
				UnitTypeId = unitType.UnitTypeId
			};
		}

	}
}
