using Company_Lab2_.Models;

namespace Company_Lab2_.Repository
{
    public interface ICrsResultRepository : IGenericRepository<CrsResult>
    {
        List<CrsResult> GetByTraineeId(int id);
        List<CrsResult> GetByCourseId(int id);
    }
}
