using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Extensions;

namespace StockTracker.Seed.Stock
{
    public class GenerateStockPar
    {
		Random _rng;

		public GenerateStockPar()
		{
			_rng = new Random();
		}

		public List<StockPar> GetStockPars(List<StockItem> stocks)
		{
			return GenerateStockPars(stocks);
		}

		List<StockPar> GenerateStockPars(List<StockItem> stocks)
		{
			var pars = new List<StockPar>();

			foreach(var item in stocks)
			{
				pars.Add(new StockPar {
					DateSet = DateTime.Now.AddDays(_rng.Next(1, 10) * -1),
					MaxStock = _rng.Next(6, 10),
					MinStock = _rng.Next(4, 6),
					StockItemId = item.StockItemId,
					IsActive = true,
					ClientId = _rng.Next(1,3)
				});
			}

			return pars;
		}
    }
}
