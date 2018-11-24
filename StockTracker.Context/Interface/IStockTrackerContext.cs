using Microsoft.EntityFrameworkCore;
using StockTracker.Model.Clients;
using StockTracker.Model.ClientStock;
using StockTracker.Model.Members;
using StockTracker.Model.Persons;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;

namespace StockTracker.Context.Interface
{
    public interface IStockTrackerContext
    {
		DbSet<Person> Persons { get; set; }
	    DbSet<Member> Members { get; set; }
	    DbSet<MemberRole> MemberRoles { get; set; }
	    DbSet<StockCore> StockCores { get; set; }
	    DbSet<ClientStockLevel> ClientStockLevel { get; set; }
	    DbSet<ClientStockItem> ClientStockItem { get; set; }
	    DbSet<ShoppingListItem> ShoppingListItems { get; set; }
	    DbSet<ShoppingList> ShoppingLists { get; set; }
	    DbSet<StockType> StockTypes { get; set; }
	    DbSet<StockCategory> StockCategories { get; set; }
	    DbSet<ClientSettings> ClientSettings { get; set; }
	    DbSet<Client> Clients { get; set; }
	}
}
