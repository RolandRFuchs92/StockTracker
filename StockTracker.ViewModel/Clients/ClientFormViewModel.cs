using System.ComponentModel.DataAnnotations;

namespace StockTracker.ViewModel.Clients
{
	public class ClientFormViewModel
	{
	public int ClientId { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string ContactNumber { get; set; }
	public string Address { get; set; }
	}
}
