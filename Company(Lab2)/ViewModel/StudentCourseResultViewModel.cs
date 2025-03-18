using Company_Lab2_.Models;
using Company_Lab2_.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Company_Lab2_.ViewModel
{
    public class StudentCourseResultViewModel
    {

        public StudentCourseResultViewModel() { 

        }
        public StudentCourseResultViewModel(CrsResult cr, ICourseRepository courseRepository , ITraineeRepository traineeRepository )
        {
            //Context context = new Context();
            Course course = courseRepository.GetById(cr.Id);// context.Courses.FirstOrDefault(c => c.Id == cr.CrsId);
                //context.Trainees.FirstOrDefault(t => t.Id == cr.TraineeId);
            Trainee trainee = traineeRepository.GetById(cr.Id);
            CrsId = cr.CrsId;
            Degree = cr.Degree;
            TraineeId = cr.TraineeId;
            MinmunDegree = course.MinmunDegree;
            ColorState = (Degree >= MinmunDegree) ? "pass" : "falild";
            CourseName = course.Name;
            TraineeName = trainee.Name;
            TraineImgURL = trainee.ImgURL;
        }

        public int CrsId { get; set; }
        public int Degree { get; set; }
        public int TraineeId { get; set; }
        public int MinmunDegree { get; set; }
        public string? ColorState { get; set; }
        public string? CourseName { get; set; }
        public string? TraineeName { get; set; }
        public string? TraineImgURL { get; set; }
    }
}
