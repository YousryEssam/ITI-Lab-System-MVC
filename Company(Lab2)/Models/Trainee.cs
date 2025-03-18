using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Lab2_.Models
{
    public class Trainee : Person
    {
        public int Level { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual List<CrsResult> crsResults { get; set; }
    }
}
