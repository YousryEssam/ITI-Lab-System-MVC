using Company_Lab2_.Models;
namespace Company_Lab2_.Repository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        List<Course> GetAllByDeptId(int id);
        List<Course> GetAllWithDepartments();
        bool GetByName(string name);
    }
}
