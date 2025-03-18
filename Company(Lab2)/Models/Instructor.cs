using Company_Lab2_.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Lab2_.Models
{
    public class Instructor : Person
    {
        public Instructor() { }
        public Instructor(InstrWithCrsViewModel ins)
        {
            Id = ins.Id;
            Name = ins.Name;
            Salary = ins.Salary;
            ImgURL = ins.ImgURL;
            CourseId = ins.CourseId;
            Address = ins.Address;
            DepartmentId = ins.DepartmentId;
        }
        public double Salary { get; set; }

        [ForeignKey("Crs")]
        public int CourseId { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Course Crs { get; set; }
        public virtual Department Department { get; set; }

    }
}
