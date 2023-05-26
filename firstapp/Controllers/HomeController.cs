using Microsoft.AspNetCore.Mvc;
using MyFirstApp.CustomModelBinder;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        [Route("/")]
        public ContentResult Index()
        {
            return Content("Yuvaraj", "text/plain");
        }


        [Route("About")]
        public ContentResult About()
        {
            return Content("{\"name\":\"yuvaraj\"}", "application/Json");
        }


        [Route("Contact")]
        public JsonResult Contact()
        {
            Employee employee = new Employee() { Id = 1, EmployeeName = "Yuvaraj", EmpExperience = 2, EmpSalary = 2342.33 };
            return new JsonResult(employee);
        }

        [Route("Blog")]
        public VirtualFileResult Blog()
        {
            return new VirtualFileResult("adhar.pdf", "application/pdf");
        }

        [Route("Download")]
        public PhysicalFileResult Download()
        {
            return new PhysicalFileResult("C:\\aspnetcore\\firstapp\\firstapp\\wwwroot\\ADHAR.pdf", "application/pdf");
        }

        [Route("Download2")]
        public FileContentResult Download2()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("C:\\aspnetcore\\firstapp\\firstapp\\wwwroot\\ADHAR.pdf");
            return new FileContentResult(bytes, "application/pdf");
        }

        [Route("book")]
        public IActionResult actionResult()
        {
            //the url should contain bookid
            if (!Request.Query.ContainsKey("bookid"))
            {

                return BadRequest("need Book id is to view the book");
            }
            //book id cant be empty
            if (String.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {

                return BadRequest("Book id cannot be empty or null");
            }

            //book id is a valid
            int bookid = Convert.ToInt32(Request.Query["bookid"]);
            if (bookid <= 0)
            {

                return BadRequest("Book id cannot be O or less than zero");
            }
            else if (bookid > 1000)
            {

                return NotFound("Book Not found");
            }

            //isloggedin is true?

            bool isloggedin = Convert.ToBoolean(Request.Query["isloggedin"]);
            if (isloggedin == false)
            {
                return Unauthorized("User Not Authorized");
            }


            return RedirectToRoute(new  {controller = "Store",action="books" });


        }
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult BookStore(int? bookid,  bool? isloggedin, Book book)
        {
            //the url should contain bookid
            if (book.BookId.HasValue == false)
            {

                return BadRequest("need Book id is to view the book");
            }
            
           

            //book id is a valid
            //int bookid = Convert.ToInt32(Request.Query["bookid"]);
            if (bookid <= 0)
            {

                return BadRequest("Book id cannot be O or less than zero");
            }
            else if (bookid > 1000)
            {

                return NotFound("Book Not found");
            }

            //isloggedin is true?

            //bool isloggedin = Convert.ToBoolean(Request.Query["isloggedin"]);
            if (isloggedin == false)
            {
                return Unauthorized("User Not Authorized");
            }


            //return Content($"<h1>book = {bookid}</h1> <br> <h1>isloggedin = {isloggedin}</h1>", "text/html");
            return Content(book.ToString());

        }

        [Route("Person")]
        public IActionResult Person ([FromForm] Person person, [FromHeader(Name ="User-Agent")] string user )
        {

            if (!ModelState.IsValid)
            {
                string error = String.Join("\n",(ModelState.Values.SelectMany(x => x.Errors).Select(a => a.ErrorMessage)));
                return BadRequest(error);
            }

            return Content($"{user}"); 
        }



    }
}
