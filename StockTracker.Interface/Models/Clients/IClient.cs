using System;

namespace StockTracker.Interface.Models.Clients
{
    public interface IClient
    {
		int ClientId { get; set; }
		string ClientName { get; set; }
		string Email { get; set; }
		string ContactNumber { get; set; }
		string Address { get; set; }
		DateTime? LastCheckup { get; set; }
		DateTime CreatedOn { get; set; }
    }
}
