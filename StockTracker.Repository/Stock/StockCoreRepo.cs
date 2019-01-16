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

namespace StockTracker.Repository.Stock
{
    public class StockCoreRepo : IStockCoreRepo
    {
        private IStockTypeRepo _stockTypeRepo;
        private IStockTrackerContext _db;
        private ILoggerAdapter<StockCoreRepo> _log;
        private IStockCategoryRepo _stockCategoryRepo;

        public StockCoreRepo(IStockTrackerContext db, ILoggerAdapter<StockCoreRepo> log, IStockTypeRepo stockTypeRepo)
        {
            _stockTypeRepo = stockTypeRepo;
            _db = db;
            _log = log;
        }

        public StockCoreRepo(IStockTrackerContext db, ILoggerAdapter<StockCoreRepo> log, IStockCategoryRepo stockCategoryRepo)
        {
            _stockCategoryRepo = stockCategoryRepo;
            _db = db;
            _log = log;
        }

        public StockCoreRepo(IStockTrackerContext db, ILoggerAdapter<StockCoreRepo> log, IStockCategoryRepo stockCategoryRepo, IStockTypeRepo stockTypeRepo)
        {
            _stockTypeRepo = stockTypeRepo;
            _stockCategoryRepo = stockCategoryRepo;
            _db = db;
            _log = log;
        }

        public StockCore Edit(IStockCore stockCore)
        {
            try
            {
                var result = ValidateStockCore(stockCore);
                if (result == null)
                    return result;

                var oldStockCore = _db.StockCores.FirstOrDefault(i => i.StockCoreId == stockCore.StockCoreId);
                oldStockCore.StockCoreName =

            }
            catch (Exception e)
            {

            }
        }

        public StockCore Add(IStockCore stockCore)
        {
            try
            {
                var result = ValidateStockCore(stockCore);
                if (result == null)
                    return result;

                _db.StockCores.Add((StockCore)stockCore);
                var newId = ((StockTrackerContext) _db).SaveChanges();
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
            throw new NotImplementedException();
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

        private StockCore ValidateStockCore(IStockCore stockCore)
        {
            if (!_stockTypeRepo.IsValid(stockCore.StockTypeId))
                return LogQuickError("StockTypeId", stockCore.StockTypeId);
            if (!_stockCategoryRepo.IsValid(stockCore.StockCategoryId))
                return LogQuickError("StockCategoryId", stockCore.StockCategoryId);

            return (StockCore)stockCore;
        }
    }
}
