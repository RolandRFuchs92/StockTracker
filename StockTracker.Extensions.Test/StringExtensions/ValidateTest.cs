using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Extensions.StringExtensions;

namespace StockTracker.Extensions.Test.StringExtensions
{
	[TestClass]
    public class ValidateTest
    {
		[TestMethod]
		public void IsValidEmail_ValidListOfEmails_True()
		{
			//Arrange
			var result = false;
			var emailList = new []
			{
				"roland@ix.co.za",
				"rolandrfuchs92@gmail.com",
				"roland.fuchs.92@gmail.com",
				"rrf92@gmail.com",
				"rfuchs@advancedapps.co.za",
				"roland@someplace.gov.za"
			};

			//Act
			
			foreach (var email in emailList)
			{
				result = email.IsValidEmail();
				if(!result) break;
			}

			//Assert
			Assert.IsTrue(result);
		}

    }
}
