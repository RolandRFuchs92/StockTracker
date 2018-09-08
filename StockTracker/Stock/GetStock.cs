using StockTracker.BusinessLogic.Interface.BusinessLogic.Stock;
using StockTracker.Context;
using StockTracker.Interface.Models.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using StockTracker.Model.Stock;
using StockTracker.Model.Stock.DTO;

namespace StockTracker.BusinessLogic.Stock
{
	public class GetStock : IGetStock
	{
		private StockTrackerContext _db;
		private IMapper _map;

		public GetStock(StockTrackerContext db, IMapper map)
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
					IsActive = stock.IsActive,
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
						IsActive = stock.IsActive,
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
						IsActive = stock.IsActive,
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
						IsActive = stock.IsActive,
						StockCategoryId = stock.StockCategoryId,
						StockItemPrice = stock.StockItemPrice,
						StockItemName = stock.StockItemName,
						DateCreated = stock.DateCreated
					}).ToList();
		}

		public List<StockItem> GetStockNotCheckedToday(int clientId)
		{
			return (from stockItem in _db.StockItems
					join stockPar in _db.StockPars
						on stockItem.StockItemId equals stockPar.StockItemId into stocks
					from stockLevel in _db.StockLevels.DefaultIfEmpty() 
						where  stockItem.StockItemId == stockLevel.StockItemId
							   && stockLevel != null
					select new StockItem
					{
						StockItemId = stockItem.StockItemId,
						IsActive = stockItem.IsActive,
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
						IsActive = stock.IsActive,
						StockCategoryId = stock.StockCategoryId,
						StockItemPrice = stock.StockItemPrice,
						StockItemName = stock.StockItemName,
						DateCreated = stock.DateCreated
					}).ToList();
		}

		private IQueryable<StockDTO> StockQuery(int clientId)
		{
			return from stockItem in _db.StockItems
				   join stockPar in _db.StockPars
					   on stockItem.StockItemId equals stockPar.StockItemId
				   join stockLevel in _db.StockLevels
					   on stockItem.StockItemId equals stockLevel.StockItemId
				   where stockPar.ClientId == clientId
				   select new StockDTO
				   {
					   StockItemId = stockItem.StockItemId,
					   ClientId = stockLevel.ClientId,
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
