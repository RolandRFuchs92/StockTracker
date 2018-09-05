using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Settings
{
    public interface IClientSettings
    {
		int ClientSettingsId { get; set; }
		int ClientId { get; set; }
		bool CanAnyoneAddStock { get; set; }
		bool CanEmailManagers { get; set; }
		DateTime OpenTime { get; set; }
		DateTime CloseTime { get; set; }
		int TotalUsers { get; set; }
		int MemberId { get; set; }
    }
}
