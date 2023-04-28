using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class HelloController : Controller
    {
        [Route("Hello")]
        public IActionResult Hello()
        {
            return View();
        }
    }
}
