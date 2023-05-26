using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class PracticeController : Controller
    {
        public IActionResult Index()
        {
            return new ViewResult(){ ViewName= "Index" };
        }
    }
}
