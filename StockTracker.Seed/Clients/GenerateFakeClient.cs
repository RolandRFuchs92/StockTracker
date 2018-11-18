using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models;

namespace StockTracker.Seed.Clients
{
	public class GenerateFakeClient
	{
		private readonly List<string> _clientNames;
		private const int maxClients = 5;
		private Random _rng;

		public GenerateFakeClient()
		{
			_clientNames = new List<string>();
			AddClientNames();
			_rng = new Random();
		}

		public List<Model.Clients.Client> GenerateClientList()
		{
			var clientList = new List<Model.Clients.Client>();

			for (var inc = 0; inc < maxClients; inc++)
			{
				var clientName = _clientNames[_rng.Next(0, 6)];
				clientList.Add(new Model.Clients.Client
				{
					Address = GenerateAddress(),
					ClientName = clientName,
					ContactNumber = _rng.Next(10000000, 999999999).ToString(),
					LastCheckup = DateTime.Now.AddDays(-_rng.Next(100)),
					CreatedOn = DateTime.Now.AddDays(_rng.Next(100)),
					Email = $"info@{clientName}.co.za"
				});
			}

			return clientList;
		}

		private void AddClientNames()
		{
			var clientNames = new List<string>
			{
				"Hole in a bread",
				"Cascata",
				"Pizza Perfect",
				"Spar Deli",
				"The Deli in Noordehoek",
				"Los Santos Pizza Parlour",
				"Nandos"
			};
			_clientNames.AddRange(clientNames);
		}

		private string GenerateAddress()
		{
			var streetNumber = _rng.Next(1, 1000);
			var streetName = RandomStreetName();
			var streetType = RandomStreetType();
			return $"{streetNumber}{streetName}{streetType}";
		}

	private string RandomStreetName()
	    {
		    switch (_rng.Next(1,5))
		    {
				case 1:
					return "Balfour";
				case 2:
					return "Albizia";
				case 3:
					return "Church";
				case 4:
					return "Protea";
				case 5:
					return "Peetee";
				default:
					return "bagfour";
		    }
	    }

	    private string RandomStreetType()
	    {
		    switch (_rng.Next(1,5))
		    {
				case 1:
					return "Street";
				case 2:
					return "Place";
				case 3:
					return "Avenue";
				case 4:
					return "Close";
				case 5:
					return "Lane";
				default:
					return "Crescent";
		    }
	    }
    }
}
