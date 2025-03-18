using Company_Lab2_.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_Lab2_.Repository
{
    public class CourseRepository : ICourseRepository
    {
        Context context;
        public CourseRepository(Context context)    
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Course course = GetById(id);
            context.Courses.Remove(course);
            return;
        }

        public List<Course> GetAll()
        {
            return context.Courses.AsNoTracking().ToList();
        }

        public List<Course> GetAllByDeptId(int id)
        {
            return context.Courses.Where(c => c.DepartmentId == id).AsNoTracking().ToList();
        }

        public List<Course> GetAllWithDepartments()
        {
            return context.Courses.Include(c => c.Department).AsNoTracking().ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public bool GetByName(string name)
        {
            return context.Courses.Any(c => c.Name == name);
        }

        public void Insert(Course obj)
        {
            context.Courses.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Course obj)
        {
            context.Courses.Update(obj);
        }
    }
}
