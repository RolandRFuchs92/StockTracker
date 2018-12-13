using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using StockTracker.Repository.Interface.Stock;

namespace StockTracker.Repository.Stock
{
    public class StockCoreRepo : IStockCoreRepo
    {

        public StockCoreRepo(IStockTrackerContext db, ILoggerAdapter<StockCoreRepo> log)
        {
            
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
            throw new NotImplementedException();
        }

        public StockCore ChangeStockDetail(int stockCoreId, int stockDetailId)
        {
            throw new NotImplementedException();
        }
    }
}
