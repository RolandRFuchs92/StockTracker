using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.ClientStock
{
    public interface IClientStockItem
    {
        int ClientStockItemId { get; set; }
		int StockCoreId { get; set; }
		int ClientId { get; set; }
		int StockMax { get; set; }
		int StockMin { get; set; }
		int CreatedOn { get; set; }
		bool IsActive { get; set; }
    }
}
