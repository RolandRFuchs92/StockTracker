using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models
{
    public interface IClient
    {
		int ClientId { get; set; }
		string ClientName { get; set; }
		string email { get; set; }
		string ContactNumber { get; set; }
		string Address { get; set; }
		DateTime LastCheckup { get; set; }
		bool IsActive { get; set; }
		DateTime CreatedOn { get; set; }
    }
}
