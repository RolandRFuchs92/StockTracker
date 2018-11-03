using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Extensions;
using StockTracker.Model.Settings;

namespace StockTracker.Seed.Settings
{
	public class GenerateClientSettings
	{
		private readonly Random _rng;
		private const int _maxClients = 5;

		public GenerateClientSettings()
		{
			_rng = new Random();
		}

		public List<ClientSettings> Generate()
		{
			return Enumerable.Range(1, _maxClients).Select(i => GenerateSingle(i)).ToList();
		}

		private ClientSettings GenerateSingle( int clientId = 1)
		{
			return new ClientSettings()
			{
				ClientId =  clientId,
				CanAnyoneAddStock = _rng.IsTrue(),
				CanEmailManagers = _rng.IsTrue(),
				CloseTime = DateTime.Now.Time(_rng.Next(13,20)),
				OpenTime = DateTime.Now.Time(_rng.Next(6,10))
			};
		}
	}
}
