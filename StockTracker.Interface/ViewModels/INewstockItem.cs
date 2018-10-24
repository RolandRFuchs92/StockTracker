using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Interface.ViewModels
{
    public interface INewstockItem
    {
	    IStockCore StockCore { get; set; }
		int MinStock { get; set; }
    }
}
