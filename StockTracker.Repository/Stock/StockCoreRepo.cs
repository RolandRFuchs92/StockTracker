using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
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
        private ILoggerAdapter<IStockCoreRepo> _log;

        public StockCoreRepo(IStockTrackerContext db, ILoggerAdapter<IStockCoreRepo> log, IStockTypeRepo stockTypeRepo)
        {
            _stockTypeRepo = stockTypeRepo;
            _db = db;
            _log = log;
        }

        public StockCore Edit(IStockCore stockCore)
        {
            throw new NotImplementedException();
        }

        public StockCore Add(IStockCore stockCore)
        {
            throw new NotImplementedException();
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
                    return LogError($"Invalid StockType[{stockTypeId}]", null);

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

        private StockCore LogError(string message, Exception e)
        {
            if (e == null)
                _log.LogError((int)LoggingEvent.Update, message);
            else
                _log.LogError((int)LoggingEvent.Update, e, message);

            return null;
        }
    }
}
