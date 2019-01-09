using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;

namespace StockTracker.Seed.Abstract
{
    public abstract class GenericSeed<T>
    {
        public abstract T[] All();

        public virtual void SeedContext(IStockTrackerContext db)
        {
            ((StockTrackerContext) db).Add(All());
            ((StockTrackerContext) db).SaveChanges();
        }

        public T One()
        {
            return All()[0];
        }

        public T One(int index)
        {
            return All()[index];
        }
    }
}
