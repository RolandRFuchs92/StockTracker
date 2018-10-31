using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
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
		[MinLength(3)]
	    public string ClientName { get; set; }
		[EmailAddress]
	    public string Email { get; set; }
		[Phone]
	    public string ContactNumber { get; set; }
		[Range(5, 120)]
	    public string Address { get; set; }
	    public DateTime? LastCheckup { get; set; }
	    public bool IsActive { get; set; }
	    public DateTime CreatedOn { get; set; }
    }
}
