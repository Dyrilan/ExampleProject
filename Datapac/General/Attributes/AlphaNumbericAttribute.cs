using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Example.General.Attributes
{
    public partial class AlphaNumbericAttribute : ValidationAttribute
    {
        private const string ALPHA_NUMERIC_REGEX = @"^[a-zA-Z0-9\s\-\.\']+$";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string stringValue)
            {
                if (!AlphaNumbericRegex().IsMatch(stringValue))
                {
                    return new ValidationResult("The field must contain only alphanumeric characters.");
                }
            }

            return ValidationResult.Success;
        }

        [GeneratedRegex(ALPHA_NUMERIC_REGEX, RegexOptions.Compiled)]
        private static partial Regex AlphaNumbericRegex();
    }
}
