using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Shopping.Config
{
    public class ShoppingListItemConfiguration : IEntityTypeConfiguration<ShoppingListItem>
    {
	    public void Configure(EntityTypeBuilder<ShoppingListItem> builder)
	    {
		    builder.HasKey(i => i.ShoppingListItemId);

		    builder.HasOne(i => i.StockCore).WithMany(i => i.ShoppingListItems).OnDelete(DeleteBehavior.Restrict);
		    builder.HasOne(i => i.ShoppingList).WithMany(i => i.ShoppingListItems).OnDelete(DeleteBehavior.Restrict);

		    builder.Property(i => i.ShoppingListItemId).HasColumnType("INT").IsRequired().ValueGeneratedOnAdd();
		    builder.Property(i => i.ShoppingListId).HasColumnType("INT").IsRequired();
		    builder.Property(i => i.CreatedOn).HasColumnType("DATETIME").IsRequired().HasDefaultValueSql("GETDATE()");
		    builder.Property(i => i.IsCollected).HasColumnType("BIT").IsRequired();
		    builder.Property(i => i.StockCoreId).HasColumnType("INT").IsRequired();
		    builder.Property(i => i.Quantity).HasColumnType("INT").IsRequired();
	    }
    }
}
