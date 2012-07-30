namespace Carbon.Validation
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	public class NonObviousPassword : ValidationAttribute
	{
		public static readonly HashSet<string> ObviousPasswords = new HashSet<string> { 
			/*NUMBERS*/		"123456", "12345", "123456789", "1234567", "12345678", "654321", "111111", "777777",
			/*PASSWORDS*/	"password", "password1", "passw0rd", "passwd", "password123", "drowssap", "secret",
			/*KEYS*/		"abc123", "abcdef", "qwerty", "zzzzzz", "zxcvbnm", "zxcvbn",
			/*PHRASES*/		"iloveyou", "letmein", "tigger", "babygirl", 
			/*COMMON*/		"link182", "monster", "princess", "lovely", "internet", "trustno1",
			/*ANIMALS*/		"monkey", "chicken", "dolphin", "falcon", "dragon", "beaver",
			/*LOCATIONS*/	"brazil", "canada", "chicago", "newyork", "sydney", 
			/*FOODS*/		"apple", "banana", "chocolate",
			/*CARS*/		"firebird", "ferrari", "porsche", "toyota", "corvette", "camaro", "bronco",
			/*SPORTS*/		"baseball", "soccer", "football", "nascar", "swimming",
			/*MOVIES*/		"ironman", "matrix", "starwars",
			/*BANDS*/		"blink182"
		};

		public static readonly HashSet<string> PopularNames = new HashSet<string> {
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

			text = text.ToLower();

			return ObviousPasswords.Contains(text) || PopularNames.Contains(text);
		}
	}
}