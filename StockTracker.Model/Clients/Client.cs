using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models;
using StockTracker.Interface.Models.Client;

namespace StockTracker.Model.Clients
{
    public class Client : IClient
    {
		[Key]
	    public int ClientId { get; set; }
	    public string ClientName { get; set; }
	    public string Email { get; set; }
	    public string ContactNumber { get; set; }
	    public string Address { get; set; }
	    public DateTime? LastCheckup { get; set; }
	    public bool IsActive { get; set; }
	    public DateTime CreatedOn { get; set; }
    }
}
