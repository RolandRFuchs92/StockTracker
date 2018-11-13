using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StockTracker.Interface.Models.Client;
using StockTracker.Model.Clients;

namespace StockTracker.Model.Clients
{
		public class ClientSettings : IClientSettings
		{
				[Key]
				public int ClientSettingsId { get; set; }
				public int ClientId { get; set; }
				public bool CanAnyoneAddStock { get; set; }
				public bool CanEmailManagers { get; set; }
				public DateTime OpenTime { get; set; }
				public DateTime CloseTime { get; set; }
				public int TotalUsers { get; set; }

				public Client Client { get; set; }
		}
}
