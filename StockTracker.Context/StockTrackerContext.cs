using Microsoft.EntityFrameworkCore;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Model.Settings;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;
using StockTracker.Model.User;

namespace StockTracker.Context
{
    public class StockTrackerContext: DbContext, IStockTrackerContext 
    {
	    public StockTrackerContext()
	    {
	    }

	    public StockTrackerContext(DbContextOptions options)
		    : base(options)
	    {
	    }

		public virtual DbSet<Person> Persons { get; set; }
	    public virtual DbSet<Member> Members { get; set; }
	    public virtual DbSet<MemberRole> MemberRoles { get; set; }
	    public virtual DbSet<StockItem> StockItems { get; set; }
	    public virtual DbSet<StockLevel> StockLevels { get; set; }
	    public virtual DbSet<StockPar> StockPars { get; set; }
	    public virtual DbSet<ShoppingListItems> ShoppingListItems { get; set; }
	    public virtual DbSet<ShoppingList> ShoppingLists { get; set; }
	    public virtual DbSet<StockType> StockTypes { get; set; }
	    public virtual DbSet<StockCategory> StockCategories { get; set; }
	    public virtual DbSet<ClientSettings> ClientSettings { get; set; }
	    public virtual DbSet<Client> Clients { get; set; }
    }
}
 