using StockTracker.Interface.Models.Shopping;
using StockTracker.Model.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Seed.ShoppingLists
{
    public class GenerateShoppingItem
    {
		private readonly Random _rng;
		public int _maxStockItems { get; set; }
		public int _minListSize { get; set; }
		public int _maxListSize { get; set; }
		public bool _isCollectedRandom { get; set; }
		public int _numberOfShoppingListsToCreate { get; set; }

		public GenerateShoppingItem()
		{
			_rng = new Random();
			_minListSize = 10;
			_maxListSize = 25;
			_isCollectedRandom = false;
		}

		public List<ShoppingListItems> GetShoppingItems()
		{
			var totalShoppingLists = new List<ShoppingListItems>();

			for(var inc = 1; inc < _numberOfShoppingListsToCreate; inc++)
			{
				totalShoppingLists.AddRange(GetSingleShippingList(inc));
			}

			return totalShoppingLists;
		}

		private List<ShoppingListItems> GetSingleShippingList(int currentShoppingListIndex)
		{
			var listSize = _rng.Next(_minListSize, _maxListSize);
			var shoppingList = new List<ShoppingListItems>();
			for(var itemIndex = 1; itemIndex < listSize; itemIndex++)
			{
				shoppingList.Add(new ShoppingListItems
				{
					IsCollected = _isCollectedRandom ? _rng.Next(0,1) > 0 : false,
					Quantity = _rng.Next(1,5),
					StockItemId = _rng.Next(1, _maxStockItems)
				});
			}

			return shoppingList;
		}

    }
}
