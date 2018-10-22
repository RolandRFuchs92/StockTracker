using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.ClientStock
{
    public interface IClientStockLevel
    {
        int ClientStockLevelId { get; set; }
		int ClientStockItemId { get; set; }
		int MemberId { get; set; }
		int Quantity { get; set; }
		DateTime CreatedOn { get; set; }
		bool IsActive { get; set; }
    }
}
