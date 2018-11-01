using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockTracker.Extensions.StringExtensions
{
	public static class Validate
	{
		public static bool IsValidEmail(this string email)
		{
			var rx = new Regex(
				@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

			if (email.EndsWith(".web"))
				return false;

			if (!rx.IsMatch(email))
				return false;

			var domain = email.Split("@")[1].Split(".");

			foreach (var splits in domain)
			{
				if (Regex.IsMatch(splits, @"\d") && domain.Length == 4 &&int.Parse(splits) > 255)
					return false;
			}

			return true;
		}

		public static bool IsPhoneNumberValid(this string phoneNumber)
		{
			 if (Regex.IsMatch(phoneNumber, @"[0-9]"))
				return false;

			var rx = new Regex(@"^\+?[1-9][0-9\s.-]{7,11}$");
			if (rx.IsMatch(phoneNumber))
				return true;

			rx = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

			return rx.IsMatch(phoneNumber.Replace(" ", ""));
		}
	}
}
