using System.ComponentModel.DataAnnotations;

namespace Company_Lab2_.Models
{
    public class MinmunDegreeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Course course = (Course)validationContext.ObjectInstance;
            int degree = course.Degree;
            int minDegree = (int)value;
            if (degree >= minDegree) { 
                return ValidationResult.Success;
            }
            return new ValidationResult("Minmun degree must be less than or equal coures degree");
        }
    }
}
