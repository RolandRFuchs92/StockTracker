using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Extensions;
using StockTracker.Model.ClientStock;

namespace StockTracker.Seed.Stock
{
    public class GenerateStockPar
    {
		Random _rng;

		public GenerateStockPar()
		{
			_rng = new Random();
		}

		public List<ClientStockItem> GetClientStockItem(List<StockCore> stocks)
		{
			return GenerateClientStockItem(stocks);
		}

		List<ClientStockItem> GenerateClientStockItem(List<StockCore> stocks)
		{
			var pars = new List<ClientStockItem>();

			foreach(var item in stocks)
			{
				pars.Add(new ClientStockItem {
					CreatedOn = DateTime.Now.AddDays(_rng.Next(0, 10) * -1),
					StockMax = _rng.Next(6, 10),
					StockMin = _rng.Next(4, 6),
					StockCoreId = item.StockCoreId,
					IsActive = true,
					ClientId = _rng.Next(1,3)
				});
			}

			return pars;
		}
    }
}
