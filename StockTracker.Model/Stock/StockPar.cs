﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Model.Stock
{
    public class StockPar : IStockPar
    {
		[Key]
	    public int StockParId { get; set; }
	    public int StockItemId { get; set; }
	    public int MaxStock { get; set; }
	    public int MinStock { get; set; }
	    public DateTime DateSet { get; set; }
    }
}
