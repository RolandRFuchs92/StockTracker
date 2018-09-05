using Microsoft.EntityFrameworkCore;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;
using StockTracker.Model;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;
using StockTracker.Model.User;

namespace StockTracker.Context.Interface
{
    public interface IStockTrackerContext
    {
        DbSet<Person> Persons { get; set; }
		DbSet<Member> Members { get; set; }
		DbSet<MemberRole> MemberRoles { get; set; }
		DbSet<StockItem> StockItems { get; set; }
		DbSet<StockLevel> StockLevels { get; set; }
		DbSet<StockPar> StockPars { get; set; }
		DbSet<ShoppingListItems> ShoppingListItems { get; set; }
		DbSet<ShoppingList> ShoppingLists { get; set; }
    }
}
