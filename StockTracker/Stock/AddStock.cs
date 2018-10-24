using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StockTracker.Context;
using StockTracker.Interface.Models.ClientStock;
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

		public bool AddNew(IStockCore stockCore)
		{
			try
			{
				var stock = _map.Map<StockCore>(stockCore);
				_db.StockCores.Add(stock);
				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public int AddNew(List<IStockCore> stockItems)
		{
			var fails = 0;

			foreach (var stock in stockItems)
				if (!AddNew(stock))
					fails++;

			return fails;
		}

		public bool Add(IStockCore stockItemId)
		{
			throw new NotImplementedException();
		}

		public int Add(List<IStockCore> stockLevels)
		{
			throw new NotImplementedException();
		}

		public bool Add(IClientStockLevel stockLevel)
		{
			try
			{
				var stock = _map.Map<IClientStockLevel>(stockLevel);
				_db.ClientStockLevel.Add((ClientStockLevel)stock);
				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public int Add(List<IClientStockLevel> stockLevels)
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
					Where(i => i.StockCore.StockCategoryId == categoryId)
					.Select(i => new ClientStockItem
					{
						ClientId = clientId,
						CreatedOn = DateTime.Now,
						StockMax =  i.StockMax,
						StockMin = i.StockMin,
						StockCoreId = i.StockCoreId
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
					.Where(i => categoryIds.Contains(i.StockCore.StockCategoryId))
					.Select(i => new ClientStockItem()
					{
						ClientId = clientId,
						CreatedOn = DateTime.Now,
						StockMax = i.StockMax,
						StockMin = i.StockMin,
						StockCoreId = i.StockCoreId
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
											.Select(stocks => stocks.StockCoreId)
											.Contains(i.StockCoreId)
									).ToList();

				fromClientStocks = fromClientStocks.Select(i => new ClientStockItem
				{
					ClientId = toClientId,
					CreatedOn = DateTime.Now,
					StockMax = i.StockMax,
					StockMin = i.StockMin,
					StockCoreId = i.StockCoreId
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
