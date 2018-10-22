using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.ClientStock;

namespace StockTracker.Model.ClientStock
{
    public class ClientStockItem : IClientStockItem
    {
	    public int ClientStockItemId { get; set; }
	    public int StockCoreId { get; set; }
	    public int ClientId { get; set; }
	    public int StockMax { get; set; }
	    public int StockMin { get; set; }
	    public int CreatedOn { get; set; }
	    public bool IsActive { get; set; }
    }
}
