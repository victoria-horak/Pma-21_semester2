using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MongoDB.Bson;
using andrew.Models;
using MongoDB.Driver;
using Newtonsoft.Json;
namespace andrew.Controllers
{
    public class KrController : Controller
    {
        private readonly KrContext _context;

        public KrController(KrContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.Alldata.ToList());
        }
        public ActionResult Convert()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("first");
            var collection = database.GetCollection<Journal>("journal");
            var halfs = collection.Find(_ => true).ToList();
            var authorList = _context.Authors.ToList();
            foreach (var author in authorList)
            {
                var half = _context.Books.FirstOrDefault(a => a.AuthorId == author.AuthorId);
                var temp = halfs.FirstOrDefault(a => System.Convert.ToInt16(a._id) == author.AuthorId);
                if (half != null && temp != null)
                {
                    var alldata = new Alldatum
                    {
                        AllDataId = author.AuthorId,
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        Title = half.Title,
                        CountPage = half.CountPage,
                        JournalTite = temp.JournalTite,
                        JournalType = temp.JournalType
                    };
                    _context.Add(alldata);
                    _context.SaveChanges();
                }

            }
            return Ok();
        }
    }

}
