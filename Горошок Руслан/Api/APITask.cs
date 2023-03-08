using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APITask : Controller
    {
        [HttpGet(Name = "GetName")]
        public string Get()
        {
            return "Hello , World!";
        }
        [HttpPost(Name = "PostName")]
        public string Post(string name)
        {
            return "Hello world " + name;
        }
    }
}
