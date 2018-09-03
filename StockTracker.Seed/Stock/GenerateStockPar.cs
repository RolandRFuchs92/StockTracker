using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Seed.Stock
{
    public class GenerateStockPar
    {
		Random _rng;

		public GenerateStockPar()
		{
			_rng = new Random();
		}

		public List<IStockPar> GetStockPars(List<IStock> stocks)
		{
			return GenerateStockPars(stocks);
		}

		List<IStockPar> GenerateStockPars(List<IStock> stocks)
		{
			var pars = new List<IStockPar>();

			foreach(var item in stocks)
			{
				pars.Add(new StockPar {
					DateSet = DateTime.Now.AddDays(_rng.Next(1, 10) * -1),
					MaxStock = _rng.Next(5, 10),
					MinStock = _rng.Next(1, 5),
					StockId = item.StockId
				});
			}

			return pars;
		}
    }
}
