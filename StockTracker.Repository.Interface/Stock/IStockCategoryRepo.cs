﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.Stock
{
		public interface IStockCategoryRepo
		{
				IStockCategory Add(string categoryName);
				IStockCategory Edit(IStockCategory stockCategory);
				List<IStockCategory> List();
				bool IsValid(int stockCategoryId);
		}
}
