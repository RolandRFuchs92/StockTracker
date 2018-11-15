using System.ComponentModel.DataAnnotations;

namespace StockTracker.ViewModel.Clients
{
    public class NewClientViewModel
    {
	    public int ClientId { get; set; }
		[Required]
		public string ClientName { get; set; }
	    public string Email { get; set; }
	    public string ContactNumber { get; set; }
	    public string Address { get; set; }
    }
}
