using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class StoreController : Controller
    {
        
        public IActionResult books()
        {
            return File("Adhar.pdf", "application/pdf");
        }
    }
}   
