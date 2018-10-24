using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StockTracker.Context;
using StockTracker.Model.Stock;
using StockTracker.Model.Stock.DTO;
using StockTracker.Repository.Interface.BusinessLogic.Stock;

namespace StockTracker.Repository.Stock
{
	public class GetStockItem : IGetStockItem
	{
		private StockTrackerContext _db;
		private IMapper _map;

		public GetStockItem(StockTrackerContext db, IMapper map)
		{
			_db = db;
			_map = map;
		}

		public List<StockItem> GetStockAbovePar(int clientId)
		{
			var results = (from stock in StockQuery(clientId)
				where stock.Quantity > stock.MaxStock
				      && stock.DateChecked > DateTime.Today
				select new StockItem
				{
					StockItemId = stock.StockItemId,
					StockCategoryId = stock.StockCategoryId,
					StockItemPrice = stock.StockItemPrice,
					StockItemName = stock.StockItemName,
					DateCreated = stock.DateCreated
				}).Distinct().ToList();
			return results;
		}

		public List<StockItem> GetAcceptableStock(int clientId)
		{
			return (from stock in StockQuery(clientId)
					where stock.Quantity > stock.MinStock
						  && stock.Quantity < stock.MaxStock
						  && stock.DateChecked > DateTime.Today
					select new StockItem
					{
						StockItemId = stock.StockItemId,
						StockCategoryId = stock.StockCategoryId,
						StockItemPrice = stock.StockItemPrice,
						StockItemName = stock.StockItemName,
						DateCreated = stock.DateCreated
					}).Distinct().ToList();
		}

		public StockItem GetStockByStockItem(int stockItemId, int clientId)
		{
			return (from stock in StockQuery(clientId)
					where stock.StockItemId == stockItemId
					orderby stock.DateSet descending 
					select new StockItem
					{
						StockItemId = stock.StockItemId,
						StockCategoryId = stock.StockCategoryId,
						StockItemPrice = stock.StockItemPrice,
						StockItemName = stock.StockItemName,
						DateCreated = stock.DateCreated
					}).FirstOrDefault();
		}

		public List<StockItem> GetStockCheckedToday(int clientId)
		{
			return (from stock in StockQuery(clientId)
					where stock.DateChecked > DateTime.Today
					select new StockItem
					{
						StockItemId = stock.StockItemId,
						StockCategoryId = stock.StockCategoryId,
						StockItemPrice = stock.StockItemPrice,
						StockItemName = stock.StockItemName,
						DateCreated = stock.DateCreated
					}).ToList();
		}

		public List<StockItem> GetStockNotCheckedToday(int clientId)
		{
			return (from stockItem in _db.StockItems
					join stockPar in _db.ClientStockItem
						on stockItem.StockItemId equals stockPar.StockItemId into stocks
					from stockLevel in _db.StockLevels.DefaultIfEmpty() 
						where stocks.Select(i => i.StockParId).Contains(stockLevel.StockParId)
							   && stockLevel != null
					select new StockItem
					{
						StockItemId = stockItem.StockItemId,
						StockCategoryId = stockItem.StockCategoryId,
						StockItemPrice = stockItem.StockItemPrice,
						StockItemName = stockItem.StockItemName,
						DateCreated = stockItem.DateCreated
					}).ToList();
		}
			
		public List<StockItem> GetStockBelowPar(int clientId)
		{
			return (from stock in StockQuery(clientId)
					where stock.DateChecked > DateTime.Today
					      && stock.Quantity < stock.MinStock
					select new StockItem
					{
						StockItemId = stock.StockItemId,
						StockCategoryId = stock.StockCategoryId,
						StockItemPrice = stock.StockItemPrice,
						StockItemName = stock.StockItemName,
						DateCreated = stock.DateCreated
					}).ToList();
		}

		private IQueryable<StockDTO> StockQuery(int clientId)
		{
			return from stockItem in _db.StockItems
				   join stockPar in _db.ClientStockItem
					   on stockItem.StockItemId equals stockPar.StockItemId
				   join stockLevel in _db.StockLevels
					   on stockPar.StockParId equals stockLevel.StockParId
				   where stockPar.ClientId == clientId
				   select new StockDTO
				   {
					   StockItemId = stockItem.StockItemId,
					   ClientId = stockPar.ClientId,
					   IsActive = stockPar.IsActive,
					   MemberId = stockLevel.MemberId,
					   MinStock = stockPar.MinStock,
					   MaxStock = stockPar.MaxStock,
					   Quantity = stockLevel.Quantity,
					   DateSet = stockPar.DateSet,
					   DateChecked = stockLevel.DateChecked,
					   StockParId = stockPar.StockParId,
					   StockLevelId = stockLevel.StockLevelId,
					   StockCategoryId = stockItem.StockCategoryId,
					   DateCreated = stockItem.DateCreated,
					   StockItemName = stockItem.StockItemName,
					   StockItemPrice = stockItem.StockItemPrice
				   };
		}
	}
}
