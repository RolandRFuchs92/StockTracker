using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Clients;

namespace StockTracker.Model.Stock
{
    public class StockPar : IStockPar
    {
		[Key]
	    public int StockParId { get; set; }
	    public int StockItemId { get; set; }
	    public int ClientId { get; set; }
	    public int MaxStock { get; set; }
	    public int MinStock { get; set; }
	    public DateTime DateSet { get; set; }
	    public bool IsActive { get; set; }

		[ForeignKey("StockItemId")]
		public StockItem StockItem { get; set; }
		[ForeignKey("ClientId")] 
	    public Client Clients { get; set; }
    }
}
