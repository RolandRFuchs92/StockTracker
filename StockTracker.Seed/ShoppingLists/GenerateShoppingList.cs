using StockTracker.Interface.Models.Shopping;
using System;
using StockTracker.Model.Shopping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Seed.ShoppingLists

{
	public class GenerateShoppingList
	{
		private const int _totalShoppingLists = 5;
		private readonly Random _rng;

		public bool isNotificationRandom {get;set;} 

		public GenerateShoppingList()
		{
			_rng = new Random();
			isNotificationRandom = true;
		}

		public List<ShoppingList> GenerateShoppingLists()
		{
			return GetShoppingLists();
		}

		private List<ShoppingList> GetShoppingLists()
		{
			var shoppingList = new List<ShoppingList>();

			for(var inc = 1; inc < _totalShoppingLists; inc++)
			{
				shoppingList.Add(new ShoppingList
				{
					DateCreated = DateTime.Now.AddDays(_rng.Next(1, 5) * -1),
					HasNotified = !isNotificationRandom && (_rng.Next(0,1)> 0),
					MemberId = _rng.Next(1,3)
				});
			}

			return shoppingList;
		}

    }
}
