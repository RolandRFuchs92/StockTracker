﻿using System;
using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStockItem
    {
		[Key]
	    int StockItemId { get; set; }
		int StockCategoryId { get; set; }
	    string StockItemName { get; set; }
		float StockItemPrice { get; set; }
		DateTime DateCreated { get; set; }
    }
}
