using Company_Lab2_.Models;
using Company_Lab2_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Company_Lab2_.Repository;
using System.Net;

namespace Company_Lab2_.Controllers
{
    public class InstructorController : Controller
    {
        //Context context = new Context();
        //////

        IInstructorRepository InstructorRepository;
        ICourseRepository CourseRepository;
        IDepartmentRepository DepartmentRepository;
        public InstructorController(IInstructorRepository instructorRepository , ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            InstructorRepository = instructorRepository;
            CourseRepository = courseRepository;
            DepartmentRepository = departmentRepository;
        }

        public IActionResult Index(int page = 0)
        {
            // size of content per page
            const int PageSize = 5;


            // Data source 
            List<Instructor> instructors = InstructorRepository.GetAll();

            // Data Prosessing
            var data = instructors.Skip(page * PageSize).Take(PageSize).ToList();

            int count = instructors.Count();
            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            // save cur page 
            ViewBag.Page = page; 

            return View("Index", data);
        }

        
        public IActionResult Details(int id)
        {
            Instructor? instructor = InstructorRepository.GetById(id);
            return View("Details" , instructor);
        }

        

        public IActionResult AddNew(InstrWithCrsViewModel InstReq)
        {
            if (InstReq.Courses == null)
            {
                InstReq.Courses = CourseRepository.GetAll(); //context.Courses.ToList();
            }
            if (InstReq.Departments == null)
            {
                InstReq.Departments = DepartmentRepository.GetAll(); //context.Departments.ToList();
            }
            if (ValidInstructor(InstReq)) {
                Instructor ins = new Instructor(InstReq);
                InstructorRepository.Insert(ins);//context.Instructors.Add(ins);
                InstructorRepository.Save();//context.SaveChanges();
                return RedirectToAction("Index", "Instructor");
            }
            return View("AddNew", InstReq);
        }

        public IActionResult Edit(int id)
        {
            Instructor instructor = InstructorRepository.GetById(id);  //context.Instructors.FirstOrDefault(i => i.Id == id);
            List<Course> courses = CourseRepository.GetAll(); //context.Courses.ToList();
            List<Department> departments = DepartmentRepository.GetAll(); //context.Departments.ToList();
            InstrWithCrsViewModel ins = new InstrWithCrsViewModel(instructor, courses, departments);
            return View("Edit", ins);
        }

        public IActionResult SaveChanges(InstrWithCrsViewModel InstReq)
        {
      
            if (ValidInstructor(InstReq))
            {
                Instructor ins = InstructorRepository.GetById(InstReq.Id); //context.Instructors.FirstOrDefault(i => i.Id == InstReq.Id);
                ins.Name = InstReq.Name;
                ins.Salary = InstReq.Salary;
                ins.ImgURL = InstReq.ImgURL;
                ins.CourseId = InstReq.CourseId;
                ins.Address = InstReq.Address;
                ins.DepartmentId = InstReq.DepartmentId;
                InstructorRepository.Save(); //context.SaveChanges();
                return RedirectToAction("Index", "Instructor");
            }
            if (InstReq.Courses == null)
            {
                InstReq.Courses = CourseRepository.GetAll(); //context.Courses.ToList();
            }
            if (InstReq.Departments == null)
            {
                InstReq.Departments = DepartmentRepository.GetAll(); //context.Departments.ToList();
            }
            return View("Edit", InstReq);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        private bool ValidInstructor(InstrWithCrsViewModel ins )
        {
            if (ins.Name == null || ins.Address == null || ins.ImgURL == null)
                return false;
            return true;
        }
    }
}
