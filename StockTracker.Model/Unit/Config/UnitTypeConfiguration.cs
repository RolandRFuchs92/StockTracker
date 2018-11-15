using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Unit.Config
{
    public class UnitTypeConfiguration : IEntityTypeConfiguration<UnitType>
    {
	    public void Configure(EntityTypeBuilder<UnitType> builder)
	    {
		    builder.HasKey(i => i.UnitTypeId);

		    builder.Property(i => i.UnitTypeId).IsRequired().HasColumnType("INT").UseSqlServerIdentityColumn();
		    builder.Property(i => i.Name).IsRequired().HasColumnType("NVARCHAR(64)");
		    builder.Property(i => i.Symbol).IsRequired().HasColumnType("NVARCHAR(8)");

		    builder.HasData();
	    }

	    UnitType[] GetUnitTypes()
	    {
		    var viewModel = new[]
		    {
				new UnitType
				{
					UnitTypeId = 1,
					Symbol = "Kg",
					Name = "Kilo gram"
				},
				new UnitType
				{
					UnitTypeId = 2,
					Symbol = "g",
					Name = "Gram"
				}, 
				new UnitType
				{
					UnitTypeId = 3,
					Symbol = "Mg",
					Name = "Milligram"
				}, 
				new UnitType
				{
					UnitTypeId = 4,
					Symbol = "U",
					Name = "Unit"
				}, 
				new UnitType
				{
					UnitTypeId = 5,
					Symbol = "l",
					Name = "Liter"
				},
				new UnitType
				{
					UnitTypeId = 6,
					Symbol = "Ml",
					Name = "Milliliter"
				}, 
				new UnitType
				{
					UnitTypeId = 7,
					Symbol = "Oz",
					Name = "Ounce"
				},
			    new UnitType
			    {
				    UnitTypeId = 8,
				    Symbol = "pt",
				    Name = "Pint"
			    },
			    new UnitType
			    {
				    UnitTypeId = 9,
				    Symbol = "qt",
				    Name = "Quart"
			    },
			    new UnitType
			    {
				    UnitTypeId = 10,
				    Symbol = "g",
				    Name = "Gallon"
			    },
			    new UnitType
			    {
				    UnitTypeId = 11,
				    Symbol = "lb",
				    Name = "Pound"
			    },
			};
		    return viewModel;
	    }
    }
}
