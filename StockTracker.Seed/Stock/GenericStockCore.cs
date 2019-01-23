using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Stock;
using StockTracker.Model.StockSupplier;
using StockTracker.Seed.Abstract;
using StockTracker.Seed.Interface;
using StockTracker.Seed.StockSupplier;

namespace StockTracker.Seed.Stock
{
		public class GenericStockCore : GenericSeed<StockCore>
		{
				public override void SeedContext(IStockTrackerContext db)
				{
						new GenericStockSupplier().SeedContext(db);

						db.StockCores.AddRange(All());
						((StockTrackerContext)db).SaveChanges();
				}

				public override StockCore[] All()
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
		}
}
