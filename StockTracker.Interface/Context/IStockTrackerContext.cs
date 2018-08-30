using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;

namespace StockTracker.Interface.Context
{
    public interface IStockTrackerContext : IDisposable
    {
        DbSet<Models.User.IStockTrackerContext> Persons { get; set; }
		DbSet<IMember> Members { get; set; }
		DbSet<IMemberRole> MemberRoles { get; set; }
		DbSet<IStock> Stocks { get; set; }
		DbSet<IStockLevel> StockLevels { get; set; }
		DbSet<IStockPar> StockPars { get; set; }
		DbSet<IShoppingListItems> ShoppingListItemses { get; set; }
		DbSet<IShoppingList> ShoppingLists { get; set; }
    }
}
