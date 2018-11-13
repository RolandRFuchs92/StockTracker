using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTracker.Model.Clients;

namespace StockTracker.Model.ClientStock.Config
{
    public class ClientStockItemConfiguration : IEntityTypeConfiguration<ClientStockItem>
    {
	    public void Configure(EntityTypeBuilder<ClientStockItem> builder)
	    {

	    }
    }
}
