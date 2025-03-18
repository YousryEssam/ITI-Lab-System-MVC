using Company_Lab2_.Repository;
using System.ComponentModel.DataAnnotations;

namespace Company_Lab2_.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        //Context context = new Context();
        ICourseRepository courseRepository;
        public UniqueAttribute(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string coursName = (string)value;
            //Course? course = context.Courses.FirstOrDefault(c => c.Name == coursName);
            if (!courseRepository.GetByName(coursName)) 
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Course Name Is already Exsit");
        }
    }
}
