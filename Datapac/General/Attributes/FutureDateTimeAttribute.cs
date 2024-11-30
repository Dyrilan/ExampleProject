using System.ComponentModel.DataAnnotations;

namespace Example.General.Attributes
{
    public class FutureDateTimeAttribute() : ValidationAttribute("The date must be in the future.")
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
                return dateTime > DateTime.UtcNow;

            return false;
        }
    }
}
