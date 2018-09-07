using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;
using StockTracker.Model.User;
using StockTracker.Seed.Client;
using StockTracker.Seed.Member;
using StockTracker.Seed.Settings;
using StockTracker.Seed.ShoppingLists;
using StockTracker.Seed.Stock;

namespace StockTracker.Seed
{
	public class PopulateDb
	{
		private readonly StockTrackerContext _db;
		private List<MemberRole> _memberRoles;
		private List<Person> _people;
		private List<StockItem> _stockItems;
		private List<Model.User.Member> _members;
		private List<ShoppingList> _shoppingList;
		private List<Model.Client.Client> _clients;

		public PopulateDb(StockTrackerContext db)
		{
			_db = db;
		}

		public void Populate()
		{
			PopulateLeaves();
			PopulateClientSettings();
			PopulateClients();
			PopulateMembers();
			PopulateClientSettings();
			PopulateStock();
			PopulateStockPars();
			PopulateShoppingLists();
			PopulateShoppingListItems();
			
		}

		private void PopulateClientSettings()
		{
			var clienSettings = new GenerateClientSettings().Generate();
			_db.ClientSettings.AddRange(clienSettings);
			_db.SaveChanges();
		}

		private void PopulateShoppingLists()
		{
			_shoppingList = new GenerateShoppingList().GenerateShoppingLists();

			_db.ShoppingLists.AddRange(_shoppingList);
			_db.SaveChanges();
		}

		private void PopulateShoppingListItems()
		{
			var gen = new GenerateShoppingItem {_maxStockItems = _shoppingList.Count};
			var shoppingItems = gen.GetShoppingItems();
			
			_db.ShoppingListItems.AddRange(shoppingItems);
			_db.SaveChanges();
		}

		private void PopulateStockPars()
		{
			var stockpars = new GenerateStockPar().GetStockPars(_stockItems);

			_db.StockPars.AddRange(stockpars);
			_db.SaveChanges();
		}

		private void PopulateStock()
		{
			var stockLevels = new GenerateStockLevel(_members.Count).GetStockLevels(_stockItems);

			_db.AddRange(stockLevels);
			_db.SaveChanges();
		}

		private void PopulateMembers()
	    {
		    _members = new GenerateFakeMembers().SetupSeedMembers(_people);

		    _db.AddRange(_members);
		    _db.SaveChanges();
	    }

		private void PopulateClients()
		{
			_db.Clients.AddRange(new GenerateFakeClient().GenerateClientList());

			_db.SaveChanges();
		}

		private void PopulateLeaves()
	    {
		    _memberRoles = new GenerateMemberRoles().GenerateMemberRole();
		    _people = new GeneratePeople().GeneratePersonList(10);
		    _stockItems = new GenerateStockItems().GetStocks();
		    _clients = new GenerateFakeClient().GenerateClientList();

			_db.MemberRoles.AddRange(_memberRoles);
			_db.Persons.AddRange(_people);
			_db.StockItems.AddRange(_stockItems);
			_db.Clients.AddRange(_clients);

		    _db.SaveChanges();
	    }
	}
}
