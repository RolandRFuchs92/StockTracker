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

namespace StockTracker.Seed
{
	public class PopulateDb
	{
		private readonly StockTrackerContext _db;
		private List<MemberRole> _memberRoles;
		private List<Person> _people;
		private List<Model.User.Member> _members;
		private List<ShoppingList> _shoppingList;
		private List<Model.Clients.Client> _clients;

		public PopulateDb(StockTrackerContext db)
		{
			_db = db;
		}

		public StockTrackerContext Populate()
		{
			return _db;

		}

		private void PopulateClientSettings()
		{
			var clienSettings = new GenerateClientSettings().Generate();
			_db.ClientSettings.AddRange(clienSettings);
			_db.SaveChanges();
		}
	}
}
