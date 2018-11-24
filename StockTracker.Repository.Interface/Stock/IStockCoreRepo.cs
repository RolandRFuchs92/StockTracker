using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.Stock
{
    public interface IStockCoreRepo
    {
        IStockCore Edit(IStockCore stockCore);
        IStockCore Add(IStockCore stockCore);
        IStockCore ChangeCategory(int stockCoreId, int stockCategoryId);
        IStockCore ChangeStockType(int stockCoreId, int stockTypeId);
        IStockCore ChangeStockDetail(int stockCoreId, int stockDetailId);
    }
}
