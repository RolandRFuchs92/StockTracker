using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Stock;
using StockTracker.Seed.Interface;

namespace StockTracker.Seed.Stock
{
    public class GenericStockCore : IGeneric<StockCore>
    {
        public GenericStockCore()
        {
            
        }

        public GenericStockCore(IStockTrackerContext db)
        {
            db.StockCores.AddRange(All());
            ((StockTrackerContext) db).SaveChanges();
        }

        public StockCore[] All()
        {
            return new[]
            {
                new StockCore
                {
                    CreatedOn = DateTime.Now,
                    StockCategoryId = 1,
                    StockCoreName = "Black Beans",
                    StockSupplierDetailId = 1,
                    StockTypeId = 1
                },
                new StockCore
                {
                    CreatedOn = DateTime.Now,
                    StockCategoryId = 1,
                    StockCoreName = "Green Beans",
                    StockSupplierDetailId = 1,
                    StockTypeId = 2
                },
                new StockCore
                {
                    CreatedOn = DateTime.Now,
                    StockCategoryId = 1,
                    StockCoreName = "Baked Beans",
                    StockSupplierDetailId = 2,
                    StockTypeId = 3
                },
            };
        }

        public StockCore One()
        {
            return All()[0];
        }

        public StockCore One(int index)
        {
            return All()[index];
        }
    }
}
