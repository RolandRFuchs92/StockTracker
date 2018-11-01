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
			var emailList = new string[]
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

		[TestMethod]
		public void IsValidEmail_InvalidListOfEmails_False()
		{
			//Arrange
			var result = false;
			var lastEmail = "";
			var emailList = new []
			{
				"plainaddress",
				"#@%^%#$@#$@#.com",
				"@domain.com",
				"Joe Smith <email@domain.com>",
				"email.domain.com",
				".email@domain.com",
				"email.@domain.com",
				"email..email@domain.com",
				"あいうえお@domain.com",
				"email@domain.com (Joe Smith)",
				"email@domain",
				"email@-domain.com",
				"email@domain.web",
				"r@at@.@moo",
				"roland@moo.zoo$coo.doo",
				"email@111.222.333.44444",
				"email@domain..com",
				"rolandatix.co.za"
			};

			//Act
			foreach (var email in emailList)
			{
				result = email.IsValidEmail();
				if (result)
				{
					lastEmail = email;
					break;
				}
			}

			//Assert
			Assert.IsFalse(result, $"{lastEmail} was the last email validated.");
		}

	    [TestMethod]
	    public void IsPhoneNumberValid_PassValidMobileNumbers_True()
	    {
		    //Arrange
		    var result = false;
		    var lastMobile = "";
		    var validMobileNumbers = new[]
		    {
				"+27123456987",
				"0831234569",
				"083 123 4569",
				"(073) 123 4569",
				"083-123-4567",
				"08 31 23 45 67"
		    };


		    //Act
		    foreach (var validMobileNumber in validMobileNumbers)
		    {
				result = validMobileNumber.IsPhoneNumberValid();
			    if (!result)
			    {
				    lastMobile = validMobileNumber;
				    break;
			    }
		    }

			//Assert
			Assert.IsTrue(result, $"{lastMobile} was the last number checked.");
		}

		[TestMethod]
		public void IsPhoneNumberInvalid_PassInvalidMobileNumbers_False()
		{
			//Arrange
			var result = false;
			var lastMobile = "";
			var invalidPoneNumberList = new[]
			{
				"as1234567890",
				"#1234567890",
				"123_123_1234",
				"##1231",
				"123",
				"12345678",
				"123+321+1234",
				"this@somemail.com",
				
			};

			//Act
			foreach (var number in invalidPoneNumberList)
			{
				result = number.IsPhoneNumberValid();
				if (result)
				{
					lastMobile = number;
					break;
				}
			}

			//Assert
			Assert.IsFalse(result, $"{lastMobile} was the last number checked.");

		}
	}
}
