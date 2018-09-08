using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Model.Stock.DTO
{
    public class StockDTO : IStockLevel, IStockPar, IStockItem
    {
	    public int StockLevelId { get; set; }
	    public int StockParId { get; set; }
	    public int StockItemId { get; set; }
	    public int StockCategoryId { get; set; }
	    public string StockItemName { get; set; }
	    public float StockItemPrice { get; set; }
	    public DateTime DateCreated { get; set; }
	    public int ClientId { get; set; }
	    public int? MaxStock { get; set; }
	    public int MinStock { get; set; }
	    public bool IsActive { get; set; }
	    public DateTime DateSet { get; set; }
	    public int Quantity { get; set; }
	    public DateTime DateChecked { get; set; }
	    public int MemberId { get; set; }
    }
}
