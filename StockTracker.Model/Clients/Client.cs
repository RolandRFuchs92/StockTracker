using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.Model.Clients
{
    public class Client : IClient
    {
	    public int ClientId { get; set; }
	    public string ClientName { get; set; }
	    public string Email { get; set; }
	    public string ContactNumber { get; set; }
	    public string Address { get; set; }
	    public DateTime? LastCheckup { get; set; }
	    public DateTime CreatedOn { get; set; }

	    public ClientSettings ClientSettings { get; set; }
	    public ICollection<Member.Member> Member { get; set; }
    }
}
