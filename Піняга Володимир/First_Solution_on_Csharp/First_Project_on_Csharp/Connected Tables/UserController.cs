using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
//using NuGet.Protocol.Plugins;
using System.Xml.Linq;
using MVC.Entities;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private MySqlConnection connection;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
        }

        ~UserController()
        {
            connection.Close();
        }

        // GET: UserController
        public ActionResult Index()
        {
            var users = new List<User>();
            //connect to mySql
            using (connection)
            {
                MySqlCommand cmd;

                //Read list of users, job and info value as null;
                cmd = new MySqlCommand("SELECT * FROM user;", connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var user = new User()
                        {
                            Id = reader.GetInt32(0),
                            Job = new Jobplace(),
                            UserInfo = new Userinfo()
                        };
                        string name = string.Empty;
                        try { name = reader.GetString(1); } catch { }
                        user.Name = name;

                        string surname = string.Empty;
                        try { surname = reader.GetString(2); } catch { }
                        user.Surname = surname;

                        users.Add(user);
                    }
                    catch { }
                }
                reader.Close();

                if (users.Count == 0)
                    return Content("No users.");

                var arrOfUserId = users.Select(obj => obj.Id).ToArray();
                var arrOfUserIdString = string.Join(",", arrOfUserId.Select(id => id.ToString()));

                //Read list of jobs
                var usersJobs = new List<Jobplace>();
                // or Jobplace
                cmd = new MySqlCommand($"SELECT * FROM `jobplace` WHERE UserId IN ({arrOfUserIdString})", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var job = new Jobplace()
                        {
                            UserId = reader.GetInt32(0)
                        };
                        string company = string.Empty;
                        try { company = reader.GetString(1); } catch { }
                        job.Company = company;

                        string location = string.Empty;
                        try { location = reader.GetString(2); } catch { }
                        job.Location = location;

                        string position = string.Empty;
                        try { position = reader.GetString(3); } catch { }
                        job.Position = position;
                        usersJobs.Add(job);
                    }
                    catch { }
                }
                reader.Close();


                //Read list of info
                var usersInfo = new List<Userinfo>();
                cmd = new MySqlCommand($"SELECT * FROM `userinfo` WHERE UserId IN ({arrOfUserIdString});", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var info = new Userinfo()
                        {
                            UserId = reader.GetInt32(0)
                        };
                        DateTime birthday = new DateTime();
                        try { birthday = reader.GetDateTime(1); } catch { }
                        info.Birthday = birthday;

                        string someInfo = string.Empty;
                        try { someInfo = reader.GetString(2); } catch { }
                        info.someInfo = someInfo;

                        usersInfo.Add(info);
                    }
                    catch { }
                }
                reader.Close();


                //Add job and info to user object
                if (usersJobs.Count != 0 || usersInfo.Count != 0)
                {
                    foreach (User user in users)
                    {
                        int index = usersJobs.FindIndex(userJob => userJob.UserId == user.Id);
                        if (index != -1)
                        {
                            user.Job = usersJobs[index];
                        }
                        index = usersInfo.FindIndex(userInfo => userInfo.UserId == user.Id);
                        if (index != -1)
                        {
                            user.UserInfo = usersInfo[index];
                        }
                    }
                }
            }
            ViewBag.ControllerName = "Index";
            return View(users);
        }

        // Get users that have all classes
        public IActionResult usersWithAllInfo()
        {
            var users = new List<User>();
            //connect to mySql
            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT user.Id, user.Name, user.Surname," +
                    " jobplace.Company, job.Location, job.Position, " +
                    " userinfo.Birthday, userinfo.someInfo FROM `user`" +
                    " INNER JOIN `jobplace` ON jobplace.UserId = user.Id" +
                    " INNER JOIN `userinfo` ON userinfo.UserId = user.Id", connection);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        var user = new User()
                        {
                            Id = reader.GetInt32(0)
                        };

                        string name = string.Empty;
                        try { name = reader.GetString(1); } catch { }
                        user.Name = name;

                        string surname = string.Empty;
                        try { surname = reader.GetString(2); } catch { }
                        user.Surname = surname;

                        //Add job info
                        string company = string.Empty;
                        try { company = reader.GetString(3); } catch { }
                        user.Job.Company = company;

                        string location = string.Empty;
                        try { location = reader.GetString(4); } catch { }
                        user.Job.Location = location;

                        string position = string.Empty;
                        try { position = reader.GetString(5); } catch { }
                        user.Job.Position = position;

                        //Add info from other table(infoUser)
                        DateTime birthday = new DateTime();
                        try { birthday = reader.GetDateTime(6); } catch { }
                        user.UserInfo.Birthday = birthday;

                        string someInfo = string.Empty;
                        try { someInfo = reader.GetString(7); } catch { }
                        user.UserInfo.someInfo = someInfo;

                        user.Job.UserId = user.UserInfo.UserId = user.Id;

                        users.Add(user);
                    }
                    catch { }
                }
                reader.Close();
            }
            ViewBag.ControllerName = "UsersWithAllInfo";
            return View("Index", users);
        }

        // GET: UserController/Where name =
        [HttpPost]
        public ActionResult SearchByName(string searchName)
        {
            ViewBag.ControllerName = "SearchByName";
            var users = new List<User>();
            //connect to mySql
            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `user` WHERE `Name` = \"{searchName}\"", connection);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        var user = new User()
                        {
                            Id = reader.GetInt32(0),
                            Job = new Jobplace(),
                            UserInfo = new Userinfo()
                        };

                        string name = string.Empty;
                        try { name = reader.GetString(1); } catch { }
                        user.Name = name;

                        string surname = string.Empty;
                        try { surname = reader.GetString(2); } catch { }
                        user.Surname = surname;

                        users.Add(user);
                    }
                    catch { }
                }
                reader.Close();

                if (users.Count == 0)
                {
                    return Content("No users with such name.");
                }

                var arrOfUserId = users.Select(obj => obj.Id).ToArray();
                var arrOfUserIdString = string.Join(",", arrOfUserId.Select(id => id.ToString()));

                //Read list of jobs
                var usersJobs = new List<Jobplace>();
                // or Jobplace
                cmd = new MySqlCommand($"SELECT * FROM `jobplace` WHERE UserId IN ({arrOfUserIdString});", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var job = new Jobplace()
                        {
                            UserId = reader.GetInt32(0)
                        };
                        string company = string.Empty;
                        try { company = reader.GetString(1); } catch { }
                        job.Company = company;

                        string location = string.Empty;
                        try { location = reader.GetString(2); } catch { }
                        job.Location = location;

                        string position = string.Empty;
                        try { position = reader.GetString(3); } catch { }
                        job.Position = position;
                        usersJobs.Add(job);
                    }
                    catch { }
                }
                reader.Close();

                //Read list of info
                var usersInfo = new List<Userinfo>();

                cmd = new MySqlCommand($"SELECT * FROM `userinfo` WHERE UserId IN ({arrOfUserIdString});", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var info = new Userinfo()
                        {
                            UserId = reader.GetInt32(0)
                        };
                        DateTime birthday = new DateTime();
                        try { birthday = reader.GetDateTime(1); } catch { }
                        info.Birthday = birthday;

                        string someInfo = string.Empty;
                        try { someInfo = reader.GetString(2); } catch { }
                        info.someInfo = someInfo;

                        usersInfo.Add(info);
                    }
                    catch { }
                }
                reader.Close();


                //Add job and info to user object
                if (usersJobs.Count != 0 || usersInfo.Count != 0)
                {
                    foreach (User user in users)
                    {
                        int index = usersJobs.FindIndex(userJob => userJob.UserId == user.Id);
                        if (index != -1)
                        {
                            user.Job = usersJobs[index];
                        }
                        index = usersInfo.FindIndex(userInfo => userInfo.UserId == user.Id);
                        if (index != -1)
                        {
                            user.UserInfo = usersInfo[index];
                        }
                    }
                }
            }
            return View("Index", users);
        }


        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (user.Name == null && user.Surname == null)
            {
                // Add temp message
                TempData["Message"] = "You haven`t add date!";
                return View(user);
            }


            MySqlCommand cmd = new MySqlCommand($"INSERT INTO `user` (Name, Surname) VALUES (\"{user.Name}\", \"{user.Surname}\");", connection);

            MySqlCommand command = new MySqlCommand("SELECT Id FROM user ORDER BY Id DESC LIMIT 1;", connection);
            MySqlDataReader reader = command.ExecuteReader();
            var TempUser = new User();
            while (reader.Read())
            {
                try
                {
                    TempUser = new User()
                    {
                        Id = reader.GetInt32(0) + 1,
                    };
                }
                catch { }
            }
            reader.Close();

            if (user.Job.Company != null || user.Job.Location != null || user.Job.Position != null)
            {
                user.Job.UserId = TempUser.Id;

                cmd.CommandText += $"INSERT INTO `jobplace` (UserId, Company, Location, Position) VALUES ({user.Job.UserId}, \"{user.Job.Company}\", \"{user.Job.Location}\", \"{user.Job.Position}\");";
            }

            if (user.UserInfo.Birthday != new DateTime() || user.UserInfo.someInfo != null)
            {
                user.UserInfo.UserId = TempUser.Id;

                cmd.CommandText += $"INSERT INTO `userinfo` (UserId, Birthday, someInfo) VALUES ({user.UserInfo.UserId}, \"{user.UserInfo.Birthday.ToString("yyy-M-d")}\", \"{user.UserInfo.someInfo}\");";
            }

            // Execute the SQL query
            int rowsAffected = cmd.ExecuteNonQuery();

            // Add temp message
            TempData["Message"] = "Record created successfully.";
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = new User();
            //connect to mySql
            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT user.Id, user.Name, user.Surname, " +
                    $"jobplace.Company, jobplace.Location, jobplace.Position, userinfo.Birthday, userinfo.someInfo FROM `user` " +
                    $"INNER JOIN `jobplace` ON jobplace.UserId = User.Id " +
                    $"INNER JOIN `userInfo` ON userInfo.UserId = User.Id where user.Id = {id}", connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        user = new User()
                        {
                            Id = reader.GetInt32(0)
                        };

                        string name = string.Empty;
                        try { name = reader.GetString(1); } catch { }
                        user.Name = name;

                        string surname = string.Empty;
                        try { surname = reader.GetString(2); } catch { }
                        user.Surname = surname;

                        //Add job info
                        string company = string.Empty;
                        try { company = reader.GetString(3); } catch { }
                        user.Job.Company = company;

                        string location = string.Empty;
                        try { location = reader.GetString(4); } catch { }
                        user.Job.Location = location;

                        string position = string.Empty;
                        try { position = reader.GetString(5); } catch { }
                        user.Job.Position = position;

                        //Add info from other table(infoUser)
                        DateTime birthday = new DateTime();
                        try { birthday = reader.GetDateTime(6); } catch { }
                        user.UserInfo.Birthday = birthday;

                        string someInfo = string.Empty;
                        try { someInfo = reader.GetString(7); } catch { }
                        user.UserInfo.someInfo = someInfo;
                    }
                    catch { }
                }
                reader.Close();
            }
            if (user.Name == "")
            {
                // Add temp message
                TempData["Message"] = "Something went wrong.";
                return View("Index");
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            MySqlCommand cmd = new MySqlCommand("", connection);

            #region Update user table
            if (user.Name == "" && user.Surname == "")
            {
                // Add temp message
                TempData["Message"] = "Date is incorrect.";
                return View(user);
            }

            if (user.Name != "" || user.Surname != "")
            {
                cmd.CommandText += $"UPDATE user SET `Name` = \"{user.Name}\", `Surname` = \"{user.Surname}\" WHERE Id = {user.Id}; ";
            }
            #endregion

            #region Update job table
            if (user.Job.Company != "" || user.Job.Location != "" || user.Job.Position != "")
            {
                MySqlCommand command = new MySqlCommand($"SELECT UserId FROM `jobplace` WHERE UserId = {user.Id};", connection);
                MySqlDataReader reader = command.ExecuteReader();

                Jobplace userInfo = new Jobplace();
                if (reader.Read())
                {
                    try
                    {
                        userInfo = new Jobplace()
                        {
                            UserId = reader.GetInt32(0)
                        };
                    }
                    catch { }
                }
                reader.Close();
                if (userInfo.UserId != 0)
                {
                    cmd.CommandText += $"UPDATE jobplace SET `Company` = \"{user.Job.Company}\", `Location`= \"{user.Job.Location}\", `Position` = \"{user.Job.Position}\" WHERE UserId = {user.Id};";
                }
                else
                {
                    cmd.CommandText += $"insert jobplace(UserId, Company, Location, Position) values({user.Id}, \"{user.Job.Company}\", \"{user.Job.Location}\", \"{user.Job.Position}\");";
                }
            }
            #endregion

            #region Update userInfo table
            if (user.UserInfo.Birthday != new DateTime() || user.UserInfo.someInfo != "")
            {
                MySqlCommand command = new MySqlCommand($"SELECT UserId FROM `userinfo` WHERE UserId = {user.Id};", connection);
                MySqlDataReader reader = command.ExecuteReader();

                Userinfo userInfo = new Userinfo();
                if (reader.Read())
                {
                    try
                    {
                        userInfo = new Userinfo()
                        {
                            UserId = reader.GetInt32(0)
                        };
                    }
                    catch { }
                }
                reader.Close();
                if (userInfo.UserId != 0)
                {
                    cmd.CommandText += $"UPDATE userinfo SET `Birthday` = \"{user.UserInfo.Birthday.ToString("yyy-M-d")}\", `someInfo`= \"{user.UserInfo.someInfo}\" WHERE UserId = {user.Id};";
                }
                else
                {
                    cmd.CommandText += $"insert jobplace(UserId, Birthday, someInfo) values({user.Id}, \"{user.UserInfo.Birthday.ToString("yyy-M-d")}\", \"{user.UserInfo.someInfo}\");";
                }
            }
            #endregion

            #region Make request 

            int rowsAffected = cmd.ExecuteNonQuery();

            #endregion

            // Add temp message
            TempData["Message"] = "Record updated successfully.";
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM user WHERE Id = {id}; DELETE FROM jobplace WHERE UserId = {id}; DELETE FROM userinfo WHERE UserId = {id};", connection);

            // Execute the command
            int rowsAffected = cmd.ExecuteNonQuery();

            // Add temp message
            TempData["Message"] = "Record deleted successfully.";

            // Redirect to the index action
            return RedirectToAction("Index");
        }

    }
}
