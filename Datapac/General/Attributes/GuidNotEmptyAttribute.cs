using System.ComponentModel.DataAnnotations;

namespace Example.General.Attributes
{
    public class GuidNotEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is Guid guidValue)
            {
                if (guidValue == Guid.Empty)
                    return new ValidationResult($"The {validationContext.MemberName} field cannot be an empty GUID.");
            }
            else if (value == null)
                return new ValidationResult($"The {validationContext.MemberName} field is required.");

            return ValidationResult.Success;
        }
    }
}
