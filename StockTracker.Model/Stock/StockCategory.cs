using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Model.Stock
{
	public class StockCategory : IStockCategory
	{
		[Key]
		public int StockCategoryId { get; set; }
		public string StockCategoryName { get; set; }

		public ICollection<StockCore> StockCore { get; set; }
	}
}