using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Model.Clients;
using StockTracker.Seed.Interface;

namespace StockTracker.Seed.Clients
{
	public class GenericClients : IGeneric<Client>
	{
		public Client[] All()
		{
			return new[]
			{
				new Client
				{
					ClientId = 1,
					Address = "Test address",
					ClientName = "Cammel Patrol",
					CreatedOn = DateTime.Now,
					ContactNumber = "0730730258",
					Email = "moo@moo.co.za"
				},
				new Client
				{
					ClientId = 2,
					Address = "Test address 2",
					ClientName = "Cammel Dog lane",
					CreatedOn = DateTime.Now,
					ContactNumber = "111 023 1234",
					Email = "moo@mooo.gov.za"
				},
				new Client
				{
					ClientId = 2,
					Address = "Test address",
					ClientName = "Camel Patrol",
					CreatedOn = DateTime.Now,
					ContactNumber = "(011) 023 1234",
					Email = "moo@111.111.111.111"
				}
			};
		}

		public Client One()
		{
			return All()[0];
		}

		public Client One(int index)
		{
			return All()[index];
		}
	}
}
