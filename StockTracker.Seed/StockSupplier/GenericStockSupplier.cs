using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Model.StockSupplier;
using StockTracker.Seed.Interface;

namespace StockTracker.Seed.StockSupplier
{
    public class GenericStockSupplier : IGeneric<StockSupplierDetail>
    {
        public StockSupplierDetail[] All()
        {
            return new[]
            {
                new StockSupplierDetail
                {
                    CreatedOn = DateTime.Now,
                    MemberId = 1,
                    Price = 100.00,

                },

            };
        }

        public StockSupplierDetail One()
        {
            throw new NotImplementedException();
        }

        public StockSupplierDetail One(int index)
        {
            throw new NotImplementedException();
        }
    }
}
