using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    [Route("/Practice")]
    public class PracticeController : Controller
    {
        [Route("/Practice/Index")]
        [Route("/Practice")]
        public IActionResult Index()
        {
            List<Employee> emp = new List<Employee>()
            {
                new Employee{  Id=1,EmployeeName = "Yuvaraj", DOB= DateTime.Parse("2000-05-13") ,EmpExperience = 2, EmpSalary = 39990, Gender = "Male", Active_id = 0 },
                new Employee{Id=2, EmployeeName = "Mary", DOB= DateTime.Parse("2000-06-12") , EmpExperience=3, EmpSalary=20000, Gender="Female", Active_id=1},
                new Employee{Id=3, EmployeeName="Dufreen",DOB= DateTime.Parse("1996-07-08") , EmpExperience=6,EmpSalary=40000, Gender="Other", Active_id=0}
            };

            emp.Add(new Employee { Id = 4, EmployeeName = "Monika", EmpExperience = 8, DOB = DateTime.Parse("1990-08-05"), EmpSalary = 80000, Gender = "Female", Active_id = 1 });

            ViewData["employee"] = emp;

            return View();
        }

        [Route("/Practice/Home")]
        public IActionResult Home()
        {
            ViewData["data"] = "Hello from Controller";
            ViewBag.info = "Hello from viewbag";
            TempData["temp"]= "Hello from tempData";
            return View();
        }
        [Route("/Practice/Details/{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return Content("Person not found");

            List<Employee> emp = new List<Employee>()
            {
                new Employee{  Id=1,EmployeeName = "Yuvaraj", DOB= DateTime.Parse("2000-05-13") ,EmpExperience = 2, EmpSalary = 39990, Gender = "Male", Active_id = 0 },
                new Employee{Id=2, EmployeeName = "Mary", DOB= DateTime.Parse("2000-06-12") , EmpExperience=3, EmpSalary=20000, Gender="Female", Active_id=1},
                new Employee{Id=3, EmployeeName="Dufreen",DOB= DateTime.Parse("1996-07-08") , EmpExperience=6,EmpSalary=40000, Gender="Other", Active_id=0}
            };

            emp.Add(new Employee { Id = 4, EmployeeName = "Monika", EmpExperience = 8, DOB = DateTime.Parse("1990-08-05"), EmpSalary = 80000, Gender = "Female", Active_id = 1 });

            Employee? employee = emp.Where(x => x.Id == id).FirstOrDefault();

            return View(employee);
        }
    }


}
