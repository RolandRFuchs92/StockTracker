using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.Stock
{
	public interface IStockPar
	{
		[Key]
		int StockParId { get; set; }
		int StockItemId { get; set; }
		int ClientId { get; set; }
		int? MaxStock { get; set; }
		int MinStock { get; set; }
		DateTime DateSet { get; set; }
	}
}
