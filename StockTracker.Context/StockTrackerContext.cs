using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockTracker.Interface.Context;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;
using IStockTrackerContext = StockTracker.Context.Interface.IStockTrackerContext;

namespace StockTracker.Context
{
    public class StockTrackerContext: DbContext, IStockTrackerContext 
    {
	    public StockTrackerContext(DbContextOptions options)
		    : base(options)
	    {
	    }

		public virtual DbSet<IPerson> Persons { get; set; }
	    public virtual DbSet<IMember> Members { get; set; }
	    public virtual DbSet<IMemberRole> MemberRoles { get; set; }
	    public virtual DbSet<IStock> Stocks { get; set; }
	    public virtual DbSet<IStockLevel> StockLevels { get; set; }
	    public virtual DbSet<IStockPar> StockPars { get; set; }
	    public virtual DbSet<IShoppingListItems> ShoppingListItemses { get; set; }
	    public virtual DbSet<IShoppingList> ShoppingLists { get; set; }
    }
}
 