using Company_Lab2_.Models;

namespace Company_Lab2_.ViewModel
{
    public class InstrWithCrsViewModel
    {
        public InstrWithCrsViewModel() { }
        public InstrWithCrsViewModel(Instructor ins , List<Course> crs , List<Department> dept) {
            Id = ins.Id;
            Name = ins.Name;
            Salary = ins.Salary;
            ImgURL = ins.ImgURL;
            CourseId = ins.CourseId;
            Address = ins.Address;
            DepartmentId = ins.DepartmentId;
            Courses = crs;
            Departments = dept;
        }
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Address { get; set; } 
        public string ImgURL { get; set; } 
        public double Salary { get; set; }
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }

        public List<Course> Courses { get; set; }

        public List<Department> Departments { get; set; }
    }
}
