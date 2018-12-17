using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.StockSupplier;
using StockTracker.Seed.Abstract;
using StockTracker.Seed.Interface;
using StockTracker.Seed.Member.Generic;
using StockTracker.Seed.Suppliers;

namespace StockTracker.Seed.StockSupplier
{
    public class GenericStockSupplier : GenericSeed<StockSupplierDetail>
    {
        public override void SeedContext(IStockTrackerContext db)
        {
            new GenericMember().SeedContext(db);
            new GenericSupplier().SeedContext(db);

            db.StockSupplierDetails.AddRange(All());
            ((StockTrackerContext) db).SaveChanges();
        }

        public override StockSupplierDetail[] All()
        {
            return new[]
            {
                new StockSupplierDetail
                {
                    CreatedOn = DateTime.Now,
                    MemberId = 1,
                    Price = 100.00m,
                    StockSupplierDetailId = 1,
                    SupplierId = 1,
                    Unit = 1,
                    UnitTypeId = 1
                },
                new StockSupplierDetail
                {
                    CreatedOn = DateTime.Now,
                    MemberId = 1,
                    Price = 120.00m,
                    StockSupplierDetailId = 2,
                    SupplierId = 2,
                    Unit = 1,
                    UnitTypeId = 1
                },
                new StockSupplierDetail
                {
                    CreatedOn = DateTime.Now,
                    MemberId = 1,
                    Price = 130.00m,
                    StockSupplierDetailId = 3,
                    SupplierId = 3,
                    Unit = 1,
                    UnitTypeId = 1
                },
            };
        }
    }
}
