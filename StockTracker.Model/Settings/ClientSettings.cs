using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Settings;
using StockTracker.Model.User;

namespace StockTracker.Model.Settings
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
	    public int MemberId { get; set; }

		[ForeignKey("MemberId")]
		public virtual Member Owner { get; set; }
		[ForeignKey("ClientId")]
		public virtual Client.Client Client { get; set; }
    }
}
