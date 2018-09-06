using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;
using StockTracker.Model;
using StockTracker.Model.Client;
using StockTracker.Model.Settings;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;
using StockTracker.Model.User;

namespace StockTracker.Context
{
    public class StockTrackerContext: DbContext, IStockTrackerContext 
    {
	    public StockTrackerContext(DbContextOptions options)
		    : base(options)
	    {
	    }

		public DbSet<Person> Persons { get; set; }
	    public DbSet<Member> Members { get; set; }
	    public DbSet<MemberRole> MemberRoles { get; set; }
	    public DbSet<StockItem> StockItems { get; set; }
	    public DbSet<StockLevel> StockLevels { get; set; }
	    public DbSet<StockPar> StockPars { get; set; }
	    public DbSet<ShoppingListItems> ShoppingListItems { get; set; }
	    public DbSet<ShoppingList> ShoppingLists { get; set; }
	    public DbSet<StockType> StockTypes { get; set; }
	    public DbSet<StockCategory> StpCategories { get; set; }
	    public DbSet<ClientSettings> ClientSettings { get; set; }
	    public DbSet<Client> Clients { get; set; }
    }
}
 