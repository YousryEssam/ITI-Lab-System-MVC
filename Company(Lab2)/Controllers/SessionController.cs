using Company_Lab2_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company_Lab2_.Controllers
{
    public class SessionController : Controller
    {
  
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "Yousry Essam");
            HttpContext.Session.SetInt32("Age", 23);
            return Content("Data Saved on Session");
        }

        public IActionResult GetSession()
        {
            string? n = HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");
            return Content($"get Session  {n}\t {a}");
        }

        public IActionResult Test() {

            //Random rnd = new Random();
            //Context context = new Context();
            //context.CrsResults.Add(new CrsResult
            //{
            //    Degree = 80,
            //    CrsId = 14,
            //    TraineeId = 2
            //});

            //context.CrsResults.Add(new CrsResult
            //{
            //    Degree = 20,
            //    CrsId = 14,
            //    TraineeId = 4
            //});
            //context.CrsResults.Add(new CrsResult
            //{
            //    Degree = 50,
            //    CrsId = 14,
            //    TraineeId = 2
            //});
            //context.SaveChanges();
            return Content("Done");
        }
    }
}
