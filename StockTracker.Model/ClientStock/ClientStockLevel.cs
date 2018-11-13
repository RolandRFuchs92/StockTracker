using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.ClientStock;

namespace StockTracker.Model.ClientStock
{
    public class ClientStockLevel : IClientStockLevel
    {
	    public int ClientStockLevelId { get; set; }
	    public int ClientStockItemId { get; set; }
	    public int MemberId { get; set; }
	    public int Quantity { get; set; }
	    public DateTime CreatedOn { get; set; }
	    public bool IsActive { get; set; }

		[ForeignKey("ClientStockItemId")]
		public virtual ClientStockItem ClientStockItem { get; set; }
		[ForeignKey("MemberId")]
		public virtual Member.Member Member { get; set; }
    }
}
