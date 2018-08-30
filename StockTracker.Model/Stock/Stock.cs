using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Model.Stock
{
    public class Stock : IStock
    {
	    public int StockId { get; set; }
	    public string StockName { get; set; }
	    public float StockPrice { get; set; }
	    public DateTime DateCreated { get; set; }
	    public bool IsActive { get; set; }
    }
}
