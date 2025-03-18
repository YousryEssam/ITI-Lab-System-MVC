using Company_Lab2_.Models;
using Company_Lab2_.Repository;
using Company_Lab2_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company_Lab2_.Controllers
{
    public class StudentCoursesResultsController : Controller
    {
        //Context context = new Context(); 
        ICrsResultRepository crsResultRepository;
        ITraineeRepository traineeRepository;
        ICourseRepository courseRepository;
        public StudentCoursesResultsController(ICrsResultRepository crsResultRepository , ITraineeRepository traineeRepository, ICourseRepository courseRepository)
        {
            this.crsResultRepository = crsResultRepository;
            this.traineeRepository = traineeRepository;
            this.courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            List<StudentCourseResultViewModel> studentCourses = new List<StudentCourseResultViewModel>();
            List<CrsResult> crs = crsResultRepository.GetAll(); //context.CrsResults.ToList();
            foreach ( var item in crs)
            {
                studentCourses.Add(new StudentCourseResultViewModel(item , courseRepository, traineeRepository));
            }
            return View(studentCourses);
        }
        public IActionResult StudentCourses(int id)
        {
            List<StudentCourseResultViewModel> studentCourses = new List<StudentCourseResultViewModel>();
            //context.CrsResults.Where(c => c.TraineeId == id);
            List<CrsResult> crs = crsResultRepository.GetByTraineeId(id); 
            foreach (var item in crs)
            {
                studentCourses.Add(new StudentCourseResultViewModel(item, courseRepository, traineeRepository));
            }
            return View("Index", studentCourses);
        }

        public IActionResult CourseStudents(int id)
        {
            List<StudentCourseResultViewModel> studentCourses = new List<StudentCourseResultViewModel>();
            List<CrsResult> crs = crsResultRepository.GetByCourseId(id); //context.CrsResults.Where(c => c.CrsId == id);
            foreach (var item in crs)
            {
                studentCourses.Add(new StudentCourseResultViewModel(item, courseRepository, traineeRepository));
            }
            return View("Index", studentCourses);
        }
    }
}
