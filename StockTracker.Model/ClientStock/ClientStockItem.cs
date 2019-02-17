using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.ClientStock;
using StockTracker.Model.Clients;
using StockTracker.Model.Stock;

namespace StockTracker.Model.ClientStock
{
	public class ClientStockItem : IClientStockItem
	{
		public int ClientStockItemId { get; set; }
		public int StockCoreId { get; set; }
		public int ClientId { get; set; }
		public int StockMax { get; set; }
		public int StockMin { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsActive { get; set; }

		public StockCore StockCore { get; set; }
		public Client Client { get; set; }
	}
}
