using System.ComponentModel.DataAnnotations;

namespace Company_Lab2_.Models
{
    public class HoursAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int hoursValue = (int)value;
            if (hoursValue % 3 == 0) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Houres in Not divided by 3.");
        }
    }
}
