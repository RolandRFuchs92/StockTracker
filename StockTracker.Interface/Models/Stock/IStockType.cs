using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStockType
    {

		/*
		 Food, drink, desert
		 i dont want to get to granular, i think its not neccessary at this point
		*/
        int StockTypeId { get; set; }
		string StockTypeName { get; set; }
    }
}
