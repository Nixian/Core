namespace Carbon.Validation
{
	using System;
	using System.Collections.ObjectModel;
	using System.Collections.Generic;
	using System.Linq;

	[Serializable]
    public class ValidationErrorCollection : Collection<ValidationError>
    {
		public void Add(string errorMessage) 
		{
			base.Add(new ValidationError(errorMessage));
		}

		public void Add(string key, string errorMessage)
		{
			var error = new ValidationError(key, errorMessage);

			base.Add(error);
		}

		public void AddRange(IEnumerable<ValidationError> errorList) 
		{
			foreach (var error in errorList) 
			{
				Add(error);
			}
		}

		public ValidationError[] GetPropertyErrors(string key)
		{
			var propertyErrors = base.Items.Where(error =>
				error.Key != null &&
				error.Key.Equals(key, StringComparison.OrdinalIgnoreCase)
			).ToArray();

			return (propertyErrors.Any()) ? propertyErrors : null;
		}

		public bool HasPropertyError(string key)
		{
			return base.Items.Any(error => 
				error.Key != null &&
				error.Key.Equals(key, StringComparison.OrdinalIgnoreCase)
			);
		}

		public ValidationError[] On(string name)
		{
			return GetPropertyErrors(name);
		}

		public ValidationError[] this[string name] 
		{
			get { return GetPropertyErrors(name); }
		}
	}
}
