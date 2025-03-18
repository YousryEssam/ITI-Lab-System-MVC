using Company_Lab2_.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_Lab2_.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        Context context;
        public TraineeRepository(Context context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            context.Trainees.Remove(GetById(id));
        }

        public List<Trainee> GetAll()
        {
            return context.Trainees.AsNoTracking().ToList();
        }

        public Trainee GetById(int id)
        {
            return context.Trainees.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Trainee obj)
        {
            context.Trainees.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Trainee obj)
        {
            context.Trainees.Update(obj);
        }
    }
}
