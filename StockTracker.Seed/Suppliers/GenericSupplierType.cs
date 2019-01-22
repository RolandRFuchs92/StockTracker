using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context.Interface;
using StockTracker.Model.Supplier;
using StockTracker.Seed.Abstract;

namespace StockTracker.Seed.Suppliers
{
    public class GenericSupplierType : GenericSeed<SupplierType>
    {
        private IStockTrackerContext _db;

        public GenericSupplierType(IStockTrackerContext db)
        {
            _db = db;
        }

        public override void SeedContext(IStockTrackerContext db)
        {
        }

        public override SupplierType[] All()
        {
            return _db.SupplierTypes.ToArray();
        }
    }
}
