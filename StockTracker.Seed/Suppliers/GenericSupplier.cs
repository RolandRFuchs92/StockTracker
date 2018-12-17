using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Model.Supplier;
using StockTracker.Seed.Abstract;

namespace StockTracker.Seed.Suppliers
{
    public class GenericSupplier : GenericSeed<Supplier>
    {
        public override Supplier[] All()
        {
            return new[]
            {
                new Supplier
                {
                    Email = "admin@bibfoods.co.za",
                    SupplierTypeId = 1,
                    Address = "9 Moo street",
                    ContactNumber = "083 123 4567",
                    SupplierLocation = "Somwhere over the rainbow",
                    SupplierName = "Bib Foods"
                },
                new Supplier
                {
                    Email = "admin@hogwardsfoods.co.za",
                    SupplierTypeId = 2,
                    Address = "16 Hog street",
                    ContactNumber = "061 789 1234",
                    SupplierLocation = "Somwhere inside the rainbow",
                    SupplierName = "Hog wards Foods"
                },
                new Supplier
                {
                    Email = "admin@ultrazoo.co.za",
                    SupplierTypeId = 3,
                    Address = "32 zoo street",
                    ContactNumber = "011 987 6543",
                    SupplierLocation = "Above the rainbow",
                    SupplierName = "Ultra Zoo Foods"
                },
            };
        }
    }
}
