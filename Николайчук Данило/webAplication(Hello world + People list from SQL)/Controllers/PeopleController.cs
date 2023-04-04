using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Text.Json;

/*using System.Web.Mvc;
*/
using webAplication.Models;

namespace webAplication.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IConfiguration _configuration;

        public PeopleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index(string name = null, string surname = null)
        {
            var users = new List<User>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //connect to mySql
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd;
                if (name == null && surname == null)
                {
                    cmd = new MySqlCommand("SELECT * from people", con);
                }
                else if (name != null && surname ==null)
                {
                    cmd = new MySqlCommand("SELECT * from people where name = @name", con);
                }
                else if (surname != null && name == null) 
                {
                    cmd = new MySqlCommand("SELECT * from people where surname = @surname", con);
                }
                else
                {
                    cmd = new MySqlCommand("SELECT * from people where name = @name AND surname = @surname", con);
                }
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var user = new User()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2)
                    };
                    users.Add(user);
                }
                reader.Close();
            }
            if (users.Count != 0)
                return View(users);
            else
                return Content("No users with such name.");
            // To return json format
/*            var options = new JsonSerializerOptions
            {
                WriteIndented = true // set this property to true to format the JSON output
            };
            return new JsonResult(users, options);*/
        }
    }
}
