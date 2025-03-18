using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Lab2_.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Hours]
        public int Hours { get; set; }

        [Required(ErrorMessage ="*")]
        [MinLength(2 ,  ErrorMessage = "Length of the name must be More than or equal 2 litters")]
        [MaxLength(20 , ErrorMessage = "Length of the name must be less than or equal 20 litters")]
        //[Unique]
        public string Name { get; set; }

        [Range(50 , 100)]
        [Required(ErrorMessage = "*")]
        public int Degree { get; set; }

        [Required(ErrorMessage = "*")]
        public int MinmunDegree { get; set; }
        
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public virtual List<CrsResult>? CrsResults { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
    }
}
