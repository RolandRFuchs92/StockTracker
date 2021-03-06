﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Model.Stock
{
	public class StockType : IStockType
	{
		[Key]
		public int StockTypeId { get; set; }
		public string StockTypeName { get; set; }

		public ICollection<StockCore> StockCore { get; set; }
	}
}