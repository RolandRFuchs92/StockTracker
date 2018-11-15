using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Shopping.Config
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
	    public void Configure(EntityTypeBuilder<ShoppingList> builder)
	    {
		    builder.HasKey(i => i.ShoppingListId);

		    builder.HasOne(i => i.Member).WithMany(i => i.ShoppingLists).OnDelete(DeleteBehavior.Restrict);
		    builder.HasMany(i => i.ShoppingListItems).WithOne(i => i.ShoppingList).OnDelete(DeleteBehavior.Restrict);


			builder.Property(i => i.ShoppingListId).IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
		    builder.Property(i => i.MemberId).IsRequired().HasColumnType("INT");
		    builder.Property(i => i.CreatedOn).IsRequired().HasColumnType("DATETIME").HasDefaultValueSql("GetDate()");
		    builder.Property(i => i.HasNotified).IsRequired().HasColumnType("BIT");
	    }
    }
}
