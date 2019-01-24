using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;

namespace StockTracker.Repository.Interface.Stock
{
    public interface IStockCoreRepo
    {
        StockCore Edit(IStockCore stockCore);
        StockCore Add(IStockCore stockCore);
        StockCore ChangeCategory(int stockCoreId, int stockCategoryId);
        StockCore ChangeStockType(int stockCoreId, int stockTypeId);
        StockCore ChangeStockDetail(int stockCoreId, int stockDetailId);
    }
}
