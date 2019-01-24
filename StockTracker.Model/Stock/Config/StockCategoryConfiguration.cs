using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Stock.Config
{
		public class StockCategoryConfiguration : IEntityTypeConfiguration<StockCategory>
		{
				public void Configure(EntityTypeBuilder<StockCategory> builder)
				{
						builder.HasKey(i => i.StockCategoryId);

						builder.HasMany(i => i.StockCore).WithOne(i => i.StockCategory).OnDelete(DeleteBehavior.Restrict);

						builder.Property(i => i.StockCategoryId).UseSqlServerIdentityColumn();
						builder.Property(i => i.StockCategoryName).IsRequired().HasColumnType("NVARCHAR(250)");

						builder.HasData(GetStockCategorySeed());
				}

				StockCategory[] GetStockCategorySeed()
				{
						var viewModel = new[]
						{
				new StockCategory
				{
					StockCategoryId = 1,
					StockCategoryName = "Meat"
				},
				new StockCategory
				{
					StockCategoryId = 2,
					StockCategoryName = "Pasta"
				},
				new StockCategory
				{
					StockCategoryId = 3,
					StockCategoryName = "Vegetable"
				},
				new StockCategory
				{
					StockCategoryId = 4,
					StockCategoryName = "Powder"
				},
				new StockCategory
				{
					StockCategoryId = 5,
					StockCategoryName = "Canned Good"
				},
				new StockCategory
				{
					StockCategoryId = 6,
					StockCategoryName = "Fruit"
				},
				new StockCategory
				{
					StockCategoryId = 7,
					StockCategoryName = "Oil"
				},
				new StockCategory
				{
					StockCategoryId = 8,
					StockCategoryName = "Edible Liquid"
				},
			};

						return viewModel;
				}
		}
}
