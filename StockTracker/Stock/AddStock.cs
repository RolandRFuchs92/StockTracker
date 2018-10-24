using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StockTracker.Context;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.ClientStock;
using StockTracker.Model.Stock;
using StockTracker.Repository.Interface.BusinessLogic.Stock;

namespace StockTracker.Repository.Stock
{
	public class AddStock : IAddStock
	{
		private StockTrackerContext _db;
		private readonly IMapper _map;

		public AddStock(StockTrackerContext db, IMapper map)
		{
			_db = db;
			this._map = map;
		}

		public bool AddNew(IStockItem stockItem)
		{
			try
			{
				var stock = _map.Map<StockItem>(stockItem);
				_db.StockItems.Add(stock);
				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public int AddNew(List<IStockItem> stockItems)
		{
			var fails = 0;

			foreach (var stock in stockItems)
				if (!AddNew(stock))
					fails++;

			return fails;
		}

		public bool Add(IStockLevel stockLevel)
		{
			try
			{
				var stock = _map.Map<StockLevel>(stockLevel);
				_db.StockLevels.Add(stock);
				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public int Add(List<IStockLevel> stockLevels)
		{
			var fails = 0;

			foreach (var stock in stockLevels)
				if (!Add(stock))
					fails++;

			return fails;
		}

		public bool AddCategory(int categoryId, int clientId)
		{
			try
			{
				var categorys = _db.
					ClientStockItem.
					Where(i => i.StockItem.StockCategoryId == categoryId)
					.Select(i => new StockPar
					{
						ClientId = clientId,
						DateSet = DateTime.Now,
						MaxStock =  i.MaxStock,
						MinStock = i.MinStock,
						StockItemId = i.StockItemId
					}).ToList();

				_db.ClientStockItem.AddRange(categorys);
				_db.SaveChanges();

				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool AddCategory(List<int> categoryIds, int clientId)
		{
			try
			{
				var categorys = _db
					.ClientStockItem
					.Where(i => categoryIds.Contains(i.StockItem.StockCategoryId))
					.Select(i => new StockPar
					{
						ClientId = clientId,
						DateSet = DateTime.Now,
						MaxStock = i.MaxStock,
						MinStock = i.MinStock,
						StockItemId = i.StockItemId
					}).ToList();

				_db.ClientStockItem.AddRange(categorys);
				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool CopyFromClient(int fromClientId, int toClientId)
		{
			try
			{
				var currentStocks = _db
									.ClientStockItem
									.Where(i => i.ClientId == toClientId);

				var fromClientStocks = _db
									.ClientStockItem
									.Where(i => i.ClientId == fromClientId 
									        && !currentStocks
											.Select(stocks => stocks.StockItemId)
											.Contains(i.StockItemId)
									).ToList();

				fromClientStocks = fromClientStocks.Select(i => new StockPar
				{
					ClientId = toClientId,
					DateSet = DateTime.Now,
					MaxStock = i.MaxStock,
					StockItemId = i.StockItemId,
					MinStock = i.MinStock
				}).ToList();

				_db.ClientStockItem.AddRange(fromClientStocks);
				_db.SaveChanges();

				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public int CopyFromClient(int fromClientId, List<int> toClientIds)
		{
			try
			{
				var ClientStockItem = _db.ClientStockItem.Where(i => i.ClientId == fromClientId && i.IsActive).ToList();
				var currentStocks = _db.ClientStockItem.Where(i => toClientIds.Contains(i.ClientId));
				var addedStocks = 0;

				foreach (var stockPar in ClientStockItem)
				{
					var clientsWithStock = currentStocks.Where(i => i.StockCoreId == stockPar.StockCoreId).Select(i => i.ClientId).ToList();
					var clientsToGetStock = toClientIds.Where(i => !clientsWithStock.Contains(i)).ToList();

					foreach (var clientId in clientsToGetStock)
					{
						_db.ClientStockItem.Add(BuildStockPar(stockPar, clientId));
						addedStocks++;
					}
				}

				return addedStocks;
			}
			catch (Exception e)
			{
				return -1;
			}
		}

		public bool EnableAllOldStock(int clientId)
		{
			try
			{
				var clientStock = _db.ClientStockItem.Where(i => i.ClientId == clientId && !i.IsActive).ToList();

				foreach (var stockPar in clientStock)
				{
					stockPar.IsActive = true;
				}

				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		private ClientStockItem BuildStockPar(ClientStockItem stockItem, int toClientId)
		{
			return new ClientStockItem
			{
				StockCoreId = stockItem.StockCoreId,
				ClientId = toClientId,
				IsActive = true,
				CreatedOn = DateTime.Now,
				StockMax = stockItem.StockMax,
				StockMin = stockItem.StockMin
			};
		}
	}
}
