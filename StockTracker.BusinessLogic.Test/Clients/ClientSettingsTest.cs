using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.Repository.Interface.Clients;

namespace StockTracker.BusinessLogic.Test.Clients
{
    public class ClientSettingsTest
    {
	    private readonly IClientSettingsLogic _clientSettingsLogic;
	    private readonly IClientSettingsRepo _clientSettingsRepo;

	    public ClientSettingsTest()
	    {
			var moq = new Mock<IClientSettingsRepo>();
		    _clientSettingsRepo = moq.Object;
	    }

		[TestMethod]
		public void Edit_PassValidClientWithNewSettings_IClientSettingsWithSameResults()
		{
			//Arrange


			//Act


			//Assert

		}
    }
}
