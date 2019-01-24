using StockTracker.Interface.Models.Stock;
using StockTracker.Repository.Interface.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Repository.Stock
{
    public class StockTypeRepo : IStockTypeRepo
    {
        public IStockType Add(string stockTypeName)
        {
            throw new NotImplementedException();
        }

        public IStockType Edit(int stockTypeId, string stockTypeName)
        {
            throw new NotImplementedException();
        }

        public List<IStockType> List()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(int stockTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
