using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Extensions.StringExtensions;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using StockTracker.Repository.Enums;
using StockTracker.Repository.Interface.Stock;
using StockTracker.Repository.Util;

namespace StockTracker.Repository.Stock
{
		public class StockCoreRepo : IStockCoreRepo
		{
				private IStockTypeRepo _stockTypeRepo;
				private IStockTrackerContext _db;
				private ILoggerAdapter<StockCoreRepo> _log;
				private IStockCategoryRepo _stockCategoryRepo;
				private ModelBinder _binder;

				private StockCoreRepo(IStockTrackerContext db, ILoggerAdapter<StockCoreRepo> log)
				{
						_binder = new ModelBinder();
						_db = db;
						_log = log;
				}

				public StockCoreRepo(IStockTrackerContext db, ILoggerAdapter<StockCoreRepo> log, IStockTypeRepo stockTypeRepo) : this(db, log)
				{
						_stockTypeRepo = stockTypeRepo;
				}

				public StockCoreRepo(IStockTrackerContext db, ILoggerAdapter<StockCoreRepo> log, IStockCategoryRepo stockCategoryRepo) : this(db, log)
				{
						_stockCategoryRepo = stockCategoryRepo;
				}

				public StockCoreRepo(IStockTrackerContext db, ILoggerAdapter<StockCoreRepo> log, IStockCategoryRepo stockCategoryRepo, IStockTypeRepo stockTypeRepo) : this(db, log)
				{
						_stockTypeRepo = stockTypeRepo;
						_stockCategoryRepo = stockCategoryRepo;
				}

				public StockCore Edit(IStockCore stockCore)
				{
						try
						{
								if (IsValidateStockCore(stockCore))
										return null;

								var oldStockCore = _db.StockCores.FirstOrDefault(i => i.StockCoreId == stockCore.StockCoreId);
								oldStockCore = _binder.Bind(oldStockCore, (StockCore)stockCore);

								((StockTrackerContext)_db).SaveChanges();
								_log.LogInformation((int)LoggingEvent.Update, $"Updated StockCore[{oldStockCore.StockCoreId}]");
								return oldStockCore;
						}
						catch (Exception e)
						{
								return LogError($"An error occured when editing StockCore[{stockCore.StockCoreId}]");
						}
				}

				public StockCore Add(IStockCore stockCore)
				{
						try
						{
								if (!IsValidateStockCore(stockCore))
										return null;

								_db.StockCores.Add((StockCore)stockCore);
								var newId = ((StockTrackerContext)_db).SaveChanges();

								_log.LogInformation((int)LoggingEvent.Create, $"Created new StockCore[{newId}]");
								return (StockCore)stockCore;
						}
						catch (Exception e)
						{
								return LogError("An error occured when adding a new StockCore.", e);
						}
				}

				public StockCore ChangeCategory(int stockCoreId, int stockCategoryId)
				{
						try
						{
								if (!IsValidStockCategory(stockCategoryId))
										return null;

								return new StockCore();
						}
						catch (Exception e)
						{
								return LogError($"There was an error Changing StockCore[{stockCoreId}] StockCategoryId to {stockCategoryId}");
						}
				}


				public StockCore ChangeStockType(int stockCoreId, int stockTypeId)
				{
						try
						{
								if (!_stockTypeRepo.IsValid(stockTypeId))
										return LogError($"Invalid StockType[{stockTypeId}]");

								var core = _db.StockCores.FirstOrDefault(i => i.StockCoreId == stockCoreId);
								var oldStockTypeId = core.StockTypeId;
								core.StockTypeId = stockTypeId;

								((StockTrackerContext)_db).SaveChanges();
								_log.LogInformation((int)LoggingEvent.Update, $"Updated StockCore[{stockCoreId}] from StockType[{oldStockTypeId}] to StockType[{stockTypeId}]");

								return core;
						}
						catch (Exception e)
						{
								return LogError($"Error occured changing StockCore[{stockCoreId}] to StockType[{stockTypeId}]", e);
						}
				}

				public StockCore ChangeStockDetail(int stockCoreId, int stockDetailId)
				{
						throw new NotImplementedException();
				}

				private StockCore LogError(string message, Exception e = null)
				{
						if (e == null)
								_log.LogError((int)LoggingEvent.Update, message);
						else
								_log.LogError((int)LoggingEvent.Update, e, message);

						return null;
				}

				StockCore LogQuickError(string objectName, int objectId, Exception e = null)
				{
						return LogError($"Invalid {objectName}[{objectId}]");
				}

				private bool IsValidateStockCore(IStockCore stockCore)
				{
						if (IsValidStockType(stockCore.StockTypeId) || IsValidStockCategory(stockCore.StockCategoryId))
								return true;

						return false;
				}

				bool IsValidStockType(int stockTypeId) 
				{
						if (_stockTypeRepo.IsValid(stockTypeId))
								return true;
						
						LogQuickError("StockTypeId", stockTypeId);
						return false;
				}

				bool IsValidStockCategory(int stockCategoryId)
				{
						if (_stockCategoryRepo.IsValid(stockCategoryId))
								return true;

						LogQuickError("StockCategoryId", stockCategoryId);
						return false;
				}
		}
}
