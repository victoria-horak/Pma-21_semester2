using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webAplication.Models;

namespace webAplication.Controllers
{
    public class HelloController : Controller
    {

        [Route("Hello")]

        public IActionResult HelloWorld()
        {
            return View();
        }
        public IActionResult HelloDen()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
