using Company_Lab2_.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_Lab2_.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        Context context;
        public DepartmentRepository(Context context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.Remove(GetById(id));
        }

        public List<Department> GetAll()
        {
            return context.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Department obj)
        {
            context.Departments.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            context.Update(obj);
        }
    }
}
