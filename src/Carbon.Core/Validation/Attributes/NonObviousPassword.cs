namespace Carbon.Validation
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class NonObviousPassword : ValidationAttribute
	{
		public static readonly HashSet<string> ObviousPasswords = new HashSet<string> { 
			/*Numbers*/		"123456", "12345", "123456789", "1234567", "12345678", "654321", "111111", "777777",
			/*Passwords*/	"password", "password1", "passw0rd", "passwd", "password123", "drowssap", "secret",
			/*Keys*/		"abc123", "abcdef", "qwerty", "zzzzzz", "zxcvbnm", "zxcvbn",
			/*Phrases*/		"iloveyou", "letmein", "tigger", "babygirl", "fuckyou",
			/*Common*/		"link182", "monster", "princess", "lovely", "internet", "trustno1", "master",
			/*Animals*/		"beaver", "chicken", "dolphin", "dragon", "falcon", "monkey",
			/*Locations*/	"brazil", "canada", "chicago", "newyork", "sydney", 
			/*Foods*/		"apple", "banana", "chocolate", "pepper",
			/*Cars*/		"firebird", "ferrari", "porsche", "toyota", "corvette", "camaro", "bronco",
			/*Sports*/		"baseball", "soccer", "football", "nascar", "swimming",
			/*Movies*/		"ironman", "matrix", "starwars",
			/*Bands*/		"blink182",

			// Popular names
			"albert", "alexis", "amanda", "andrea", "andrew", "angela",  "anthony", "ashley", "arthur",
			"bonnie", "brandon", "brandy",
			"daniel", "danielle", "debbie", "dennis",
			"gandalf", "gemini", "george", "gordon", "gregory",
			"hannah",
			"jackie", "jackson", "jasmine", "jasper", "jason", "jennifer", "jeremy", "jessica", "johnny", "johnson", "jordan", "joseph", "joshua",
			"matthew", "martin", "marvin", "maxwell", "michael", "michelle", "mickey", "morgan",
			"nathan", "nicholas", "nicole",
			"patrick", 
			"taylor", "tiffany", 
			"victor", 
			"wilson"
		};

		public override bool IsValid(object value)
		{
			var text = value as string;

			if (string.IsNullOrEmpty(text)) 
				return true;

			text = text.ToLower().Trim();

			return !ObviousPasswords.Contains(text);
		}
	}
}