using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Suppliers.Config
{
    public class SupplierTypeConfiguration : IEntityTypeConfiguration<SupplierType>
    {
	    public void Configure(EntityTypeBuilder<SupplierType> builder)
	    {
		    builder.HasKey(i => i.SupplierTypeId);

		    builder.HasMany(i => i.Suppliers).WithOne(i => i.SupplierType);

		    builder.Property(i => i.SupplierTypeId).UseSqlServerIdentityColumn();
		    builder.Property(i => i.SupplierTypeName).IsRequired().HasColumnType("NVARCHAR(256)");

		    builder.HasData(GetSupplierType());
	    }

	    SupplierType[] GetSupplierType()
	    {
		    var viewModel = new[]
		    {
				new SupplierType
				{
					SupplierTypeId = 1,
					SupplierTypeName = "Grocer"
				},
				new SupplierType
				{
					SupplierTypeId = 2,
					SupplierTypeName = "Butcher"
				}, 
				new SupplierType
				{
					SupplierTypeId = 3,
					SupplierTypeName = "Caterer"
				},
				new SupplierType
				{
					SupplierTypeId = 4,
					SupplierTypeName = "Super Market"
				},
				new SupplierType
				{
					SupplierTypeId = 5,
					SupplierTypeName = "Farmer"
				}
		    };
		    return viewModel;
	    }

    }
}
