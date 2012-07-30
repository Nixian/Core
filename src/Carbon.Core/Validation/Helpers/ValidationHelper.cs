namespace Carbon.Validation
{
	using System;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Globalization;

	using Carbon.Helpers;

	public static class ValidationHelper
	{
		public const string EmailAddressRegexPattern = 
			@"^([a-zA-Z0-9_\-\.\+]+)@((\[[0-9]{1,3}" +
			@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
			@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

		public static readonly Regex EmailAddressRegex = new Regex(EmailAddressRegexPattern, RegexOptions.Compiled);

		/// <summary>
		/// Performs the Luhn check.
		/// </summary>
		/// <param name="cardNumber">Credit Card Number</param>
		/// <author>Frode N. Rosand</author>
		public static bool IsValidCreditCardNumber(string cardNumber)
		{
			if (cardNumber.IsNullOrEmpty()) return false;

			int length = cardNumber.Length;

			// Between 13 and 16 chars
			if (!length.InRange(13, 16)) return false;

			int sum = 0;
			int offset = length % 2;
			byte[] digits = Encoding.ASCII.GetBytes(cardNumber);

			for (int i = 0; i < length; i++)
			{
				digits[i] -= 48;

				if (((i + offset) % 2) == 0) 
				{
					digits[i] *= 2;
				}

				sum += (digits[i] > 9) ? digits[i] - 9 : digits[i];
			}

			return ((sum % 10) == 0);
		}

		public static bool ContainsOnlyLettersOrDigits(this string text)
		{
			return text.All(Char.IsLetterOrDigit);
		}

		public static bool IsNumeric(this string text)
		{
			return text.All(Char.IsDigit);
		}

		public static bool IsAlphaNumeric(this string text)
		{
			var alphaNumericPattern = new Regex("[^a-zA-Z0-9]");

			return !alphaNumericPattern.IsMatch(text);
		}

		public static bool ContainsNumbers(this string text)
		{
			return text.Any(Char.IsDigit);
		}

        public static bool IsValidEmailAddress(this string email)
		{
			if (email.IsNullOrEmpty()) return false;

			return EmailAddressRegex.IsMatch(email);
		}

		public static bool IsValidInteger(this string text)
		{
			Int64 intValue;

			return Int64.TryParse(text, out intValue);
		}
	}
}