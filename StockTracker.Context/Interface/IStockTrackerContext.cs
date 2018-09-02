using Microsoft.EntityFrameworkCore;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;
using StockTracker.Model;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;

namespace StockTracker.Context.Interface
{
    public interface IStockTrackerContext
    {
        DbSet<Person> Persons { get; set; }
		DbSet<Member> Members { get; set; }
		DbSet<MemberRole> MemberRoles { get; set; }
		DbSet<Stock> Stocks { get; set; }
		DbSet<StockLevel> StockLevels { get; set; }
		DbSet<StockPar> StockPars { get; set; }
		DbSet<ShoppingListItems> ShoppingListItemses { get; set; }
		DbSet<ShoppingList> ShoppingLists { get; set; }
    }
}
