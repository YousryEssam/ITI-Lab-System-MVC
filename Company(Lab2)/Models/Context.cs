using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Company_Lab2_.Models
{
    public class Context : DbContext
    {
        public DbSet<Course> Courses { set; get;}
        public DbSet<Trainee> Trainees { set; get;}
        public DbSet<CrsResult> CrsResults { set; get;}
        public DbSet<Department> Departments { set; get;}
        public DbSet<Instructor> Instructors { set; get;}

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = "Data Source=YOUSRY\\YOUSRY;Initial Catalog=CompanyMVC2;Integrated Security=True;Encrypt=False";
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
