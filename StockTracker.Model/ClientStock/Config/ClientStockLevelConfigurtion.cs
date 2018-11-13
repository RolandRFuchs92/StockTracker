using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockTracker.Model.ClientStock.Config
{
    public class ClientStockLevelConfigurtion : IEntityTypeConfiguration<ClientStockLevel>
    {
	    public void Configure(EntityTypeBuilder<ClientStockLevel> builder)
	    {
		    throw new NotImplementedException();
	    }
    }
}
