using System;
using System.Collections.Generic;

namespace StockTracker.Interface.Models.Stock
{
	public interface IStockPar
	{
		int StockParId { get; set; }
		int StockId { get; set; }
		int MaxStock { get; set; }
		int MinStock { get; set; }
		DateTime DateSet { get; set; }
	}
}
