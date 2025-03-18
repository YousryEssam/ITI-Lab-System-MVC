using Company_Lab2_.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_Lab2_.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        Context context;
        public InstructorRepository(Context context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            Instructor instructor = GetById(id);
            context.Instructors.Remove(instructor);
            return;
        }

        public List<Instructor> GetAll()
        {
            return context.Instructors.AsNoTracking().ToList();
        }

        public Instructor GetById(int id)
        {
            return context.Instructors.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(Instructor obj)
        {
            context.Instructors.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Instructor obj)
        {
            context.Instructors.Update(obj);
        }
    }
}
