using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface
{
	public interface IStockPar
	{
		int StockParId { get; set; }
		int StockId { get; set; }
		int MaxStock { get; set; }
		int MinStock { get; set; }
		DateTime DateSet { get; set; }

		List<IStock> Stocks { get; set; }
	}
}
