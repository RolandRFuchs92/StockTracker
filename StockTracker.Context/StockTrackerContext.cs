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
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;

namespace StockTracker.Context
{
    public class StockTrackerContext: DbContext, IStockTrackerContext 
    {
	    public StockTrackerContext(DbContextOptions options)
		    : base(options)
	    {
	    }

		public virtual DbSet<Person> Persons { get; set; }
	    public virtual DbSet<Member> Members { get; set; }
	    public virtual DbSet<MemberRole> MemberRoles { get; set; }
	    public virtual DbSet<Stock> Stocks { get; set; }
	    public virtual DbSet<StockLevel> StockLevels { get; set; }
	    public virtual DbSet<StockPar> StockPars { get; set; }
	    public virtual DbSet<ShoppingListItems> ShoppingListItemses { get; set; }
	    public virtual DbSet<ShoppingList> ShoppingLists { get; set; }
    }
}
 