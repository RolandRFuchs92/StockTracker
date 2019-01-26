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
				var newUnit = EmptyFieldCheck(name, symbol);
				if (newUnit == null)
				{
					LogError(LoggingEvent.Error, $"The name value was empty.");
					return null;
				}

				_db.UnitTypes.Add(newUnit);
				_db.SaveChanges();

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
				if (_db.UnitTypes.Any(i => i.UnitTypeId == unitType.UnitTypeId))
					return null;

				if (EmptyFieldCheck(unitType.Name, unitType.Symbol) == null)
					return null;

				_db.UnitTypes.Add((UnitType)unitType);
				_db.SaveChanges();

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

		UnitType EmptyFieldCheck(string name, string symbol)
		{
			if (string.IsNullOrEmpty(name))
			{
				LogError(LoggingEvent.Error, $"The name value was empty.");
				return null;
			}

			if (string.IsNullOrEmpty(symbol))
			{
				LogError(LoggingEvent.Error, $"The symbol value was empty.");
				return null;
			}

			return new UnitType
			{
				Name = name,
				Symbol = symbol
			};
		}

	}
}
