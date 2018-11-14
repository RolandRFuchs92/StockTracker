using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Stock.Config
{
    public class StockTypeConfiguration : IEntityTypeConfiguration<StockType>
    {
	    public void Configure(EntityTypeBuilder<StockType> builder)
	    {
		    builder.HasKey(i => i.StockTypeId);

		    builder.Property(i => i.StockTypeId).HasColumnType("INT").IsRequired().ValueGeneratedOnAdd();
		    builder.Property(i => i.StockTypeName).HasColumnType("NVARCHAR(200)").IsRequired();

		    builder.HasData(GetStockTypeSeedData());
	    }

	    StockType[] GetStockTypeSeedData()
	    {
		    var viewModel = new[]
		    {
			    new StockType
			    {
					StockTypeId = 1,
					StockTypeName = "Frozen Treat"
			    },
			    new StockType
			    {
				    StockTypeId = 2,
				    StockTypeName = "Raw Fruit"
			    },
			    new StockType
			    {
				    StockTypeId = 3,
				    StockTypeName = "Sugar"
			    },
			    new StockType
			    {
				    StockTypeId = 4,
				    StockTypeName = "Cooking Oil"
			    },
			    new StockType
			    {
				    StockTypeId = 5,
				    StockTypeName = "Chicken"
			    },
			    new StockType
			    {
				    StockTypeId = 6,
				    StockTypeName = "Fish"
			    },
			    new StockType
			    {
				    StockTypeId = 7,
				    StockTypeName = "Pork"
			    },
			    new StockType
			    {
				    StockTypeId = 8,
				    StockTypeName = "Beef"
			    },
			    new StockType
			    {
				    StockTypeId = 9,
				    StockTypeName = "Sauce"
			    },
			    new StockType
			    {
				    StockTypeId = 10,
				    StockTypeName = "Spice"
			    },
			    new StockType
			    {
				    StockTypeId = 11,
				    StockTypeName = "Canned Fruit"
			    },
			    new StockType
			    {
				    StockTypeId = 12,
				    StockTypeName = "Canned Vegetable"
			    },
			    new StockType
			    {
				    StockTypeId = 13,
				    StockTypeName = "Canned Meat"
			    },
			    new StockType
			    {
				    StockTypeId = 14,
				    StockTypeName = "Soda"
			    },
			    new StockType
			    {
				    StockTypeId = 15,
				    StockTypeName = "Fruit Juice"
			    },
			    new StockType
			    {
				    StockTypeId = 16,
				    StockTypeName = "Beer"
			    },
			    new StockType
			    {
				    StockTypeId = 17,
				    StockTypeName = "Wine"
			    },
			    new StockType
			    {
				    StockTypeId = 18,
				    StockTypeName = "Cider"
			    },
			    new StockType
			    {
				    StockTypeId = 19,
				    StockTypeName = "Water"
			    },
			    new StockType
			    {
				    StockTypeId = 20,
				    StockTypeName = "Yogurt"
			    },
			    new StockType
			    {
				    StockTypeId = 21,
				    StockTypeName = "Cream"
			    },
			};


		    return viewModel;
	    }
    }
}
