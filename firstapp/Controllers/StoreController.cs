using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books")]
        public IActionResult Index()
        {
            return File("Adhar.pdf", "application/pdf");
        }
    }
}   
