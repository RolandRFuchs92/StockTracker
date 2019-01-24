using System;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Seed.Abstract;
using StockTracker.Seed.Interface;

namespace StockTracker.Seed.Clients.Generic
{
	public class GenericClients : GenericSeed<Client>
	{
		public override Client[] All()
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
					ClientId = 3,
					Address = "Test address",
					ClientName = "Camel Patrol",
					CreatedOn = DateTime.Now,
					ContactNumber = "(011) 023 1234",
					Email = "moo@111.111.111.111"
				}
			};
		}
	}
}
