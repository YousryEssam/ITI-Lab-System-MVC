using Company_Lab2_.Models;
using Company_Lab2_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace Company_Lab2_.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository CourseRepository;
        IDepartmentRepository DepartmentRepository;
        public CourseController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            CourseRepository = courseRepository;
            DepartmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            // Context context = new Context();
            //context.Courses.Include(c => c.Department).ToList();
            List<Course> courses = CourseRepository.GetAllWithDepartments(); 
            return View(courses);
        }

        public IActionResult GetAllByDeptId(int id)
        {
            //Context context = new Context();
            //context.Courses.Where(c => c.DepartmentId == id).ToList();
            List<Course> courses = CourseRepository.GetAllByDeptId(id);
            return Json(courses);
        }

        public IActionResult AddNew()
        {
            //Context context = new Context();
            ViewData["Depts"] = DepartmentRepository.GetAll(); //context.Departments.ToList();
            return View("AddNew");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Course CrsFromCreation) {
            //Context context = new Context();
            if (ModelState.IsValid == true)
            {
                try
                {
                    //context.Courses.Add(CrsFromCreation);
                    CourseRepository.Insert(CrsFromCreation);
                    //context.SaveChanges();
                    CourseRepository.Save();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("DepartmentId", "Invalid Department");
                }
               
            }
            //context.Departments.ToList();
            ViewBag.Depts = DepartmentRepository.GetAll(); 
            return View("AddNew", CrsFromCreation);
        }
    }
}
