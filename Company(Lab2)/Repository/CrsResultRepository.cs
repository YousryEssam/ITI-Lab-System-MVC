using Company_Lab2_.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_Lab2_.Repository
{
    public class CrsResultRepository : ICrsResultRepository
    {
        Context context;
        public CrsResultRepository(Context context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.CrsResults.Remove(GetById(id));
        }

        public List<CrsResult> GetAll()
        {
            return context.CrsResults.AsNoTracking().ToList();
        }

        public List<CrsResult> GetByCourseId(int id)
        {
            return context.CrsResults.Where(c => c.CrsId == id).AsNoTracking().ToList();
        }

        public CrsResult GetById(int id)
        {
            return context.CrsResults.FirstOrDefault(c => c.Id == id);
        }

        public List<CrsResult> GetByTraineeId(int id)
        {
            return context.CrsResults.Where(c => c.TraineeId == id).AsNoTracking().ToList();
        }

        public void Insert(CrsResult obj)
        {
            context.CrsResults.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(CrsResult obj)
        {
            context.CrsResults.Update(obj);
        }
    }
}
