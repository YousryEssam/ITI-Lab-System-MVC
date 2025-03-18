using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Lab2_.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Crs")]
        public int CrsId { get; set; }
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public virtual Trainee Trainee { get; set; }
        public virtual Course Crs { get; set; }
    }
}
