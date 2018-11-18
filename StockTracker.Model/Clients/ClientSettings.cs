using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;

namespace StockTracker.Model.Clients
{
	public class ClientSettings : IClientSettings
	{
		public int ClientSettingsId { get; set; }
		public int ClientId { get; set; }
		public bool CanAnyoneAddStock { get; set; }
		public bool CanEmailManagers { get; set; }
		public DateTime OpenTime { get; set; }
		public DateTime CloseTime { get; set; }
		public int TotalUsers { get; set; }
		public bool IsActive { get; set; }
		public bool? IsDeleted { get; set; }
		public DateTime? DateDeleted { get; set; }

		public Client Client { get; set; }
	}
}
