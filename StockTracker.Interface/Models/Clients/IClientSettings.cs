using System;
using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.Clients
{
    public interface IClientSettings
    {
		[Key]
		int ClientSettingsId { get; set; }
		int ClientId { get; set; }
		bool CanAnyoneAddStock { get; set; }
		bool CanEmailManagers { get; set; }
		DateTime OpenTime { get; set; }
		DateTime CloseTime { get; set; }
		int TotalUsers { get; set; }
	    bool IsActive { get; set; }
	    bool? IsDeleted { get; set; }
		DateTime? DateDeleted { get; set; }
	}
}
