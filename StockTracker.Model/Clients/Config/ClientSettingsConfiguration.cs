using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.Clients.Config
{
    public class ClientSettingsConfiguration : IEntityTypeConfiguration<ClientSettings>
    {
	    public void Configure(EntityTypeBuilder<ClientSettings> builder)
	    {
		    throw new NotImplementedException();
	    }
    }
}
