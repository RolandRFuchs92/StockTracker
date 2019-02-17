using StockTracker.Interface.Models.Stock;
using StockTracker.Repository.Interface.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Stock;
using StockTracker.Repository.Enums;
using StockTracker.Repository.Util;

namespace StockTracker.Repository.Stock
{
	public class StockCategoryRepo : Logging<StockCategoryRepo>, IStockCategoryRepo
	{
		private readonly StockTrackerContext _db;

		public StockCategoryRepo(IStockTrackerContext db, ILoggerAdapter<StockCategoryRepo> _log) :base(_log)
		{
			_db = (StockTrackerContext) db;
		}

		public IStockCategory Add(string categoryName)
		{
			try
			{
				var isEmpty = string.IsNullOrEmpty(categoryName);
				if (isEmpty || _db.StockCategories.Any(i => i.StockCategoryName == categoryName))
				{
					LogError(LoggingEvent.Error, isEmpty ? "No Category Name passed." : $"CaregoryName {categoryName} already exists");
					return null;
				}

				var model = new StockCategory
				{
					StockCategoryName = categoryName
				};

				_db.StockCategories.Add(model);
				_db.SaveChanges();

				LogInformation(LoggingEvent.Create, $"Added [{categoryName}]");

				return model;
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"There was an error adding new Category[{categoryName}]", e);
				return null;
			}
		}

		public IStockCategory Edit(IStockCategory stockCategory)
		{
			try
			{
				var isEmpty = string.IsNullOrEmpty(stockCategory.StockCategoryName);
				if (isEmpty || _db.StockCategories.Any(i => i.StockCategoryName == stockCategory.StockCategoryName))
				{
					LogError(LoggingEvent.Error, isEmpty ? "StockCategory.Name was not passed." : $"StockCategory.Name[{stockCategory.StockCategoryName}] already exsists in the current db.");
					return null;
				}

				var model = _db.StockCategories.FirstOrDefault(i => i.StockCategoryId == stockCategory.StockCategoryId);

				if (model == null)
				{
					LogError(LoggingEvent.Error, $"StockCategory[{stockCategory.StockCategoryId}] does not exist.");
					return null;
				}

				var oldCategoryName = model.StockCategoryName;
				model.StockCategoryName = stockCategory.StockCategoryName;
				_db.SaveChanges();

				LogInformation(LoggingEvent.Update, $"Updated StockCategory[{model.StockCategoryId}].StockCategoryName[{oldCategoryName}] to StockCategoryName[{stockCategory.StockCategoryName}]");

				return model;
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"There was an error editing StockCategory[{stockCategory.StockCategoryId}]", e);
				return null;
			}
		}


		public bool IsValid(int stockCategoryId)
		{
			throw new NotImplementedException();
		}

		public List<IStockCategory> List()
		{
			throw new NotImplementedException();
		}
	}
}
