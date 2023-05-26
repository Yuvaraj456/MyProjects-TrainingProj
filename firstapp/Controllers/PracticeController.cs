using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class PracticeController : Controller
    {
        [Route("Practice")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
