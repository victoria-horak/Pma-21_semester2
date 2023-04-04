using conectedTables.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using NuGet.Protocol.Plugins;
using System.Xml.Linq;

namespace conectedTables.Controllers
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
                            Job = new Job(),
                            UserInfo = new UserInfo()
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
                var usersJobs = new List<Job>();
                cmd = new MySqlCommand($"SELECT * FROM `Job` WHERE userId IN ({arrOfUserIdString})", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var job = new Job()
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
                var usersInfo = new List<UserInfo>();
                cmd = new MySqlCommand($"SELECT * FROM `userinfo` WHERE userId IN ({arrOfUserIdString});", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var info = new UserInfo()
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
                MySqlCommand cmd = new MySqlCommand("SELECT user.id, user.name, user.surname," +
                    " job.company, job.location, job.position, " +
                    " userinfo.birthday, userinfo.someinfo FROM `user`" +
                    " INNER JOIN `job` ON job.userId = user.id" +
                    " INNER JOIN `userinfo` ON userinfo.userId = user.id", connection);

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
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `user` WHERE `name` = \"{searchName}\"", connection);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        var user = new User()
                        {
                            Id = reader.GetInt32(0),
                            Job = new Job(),
                            UserInfo = new UserInfo()
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
                var usersJobs = new List<Job>();

                cmd = new MySqlCommand($"SELECT * FROM `Job` WHERE userId IN ({arrOfUserIdString});", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var job = new Job()
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
                var usersInfo = new List<UserInfo>();

                cmd = new MySqlCommand($"SELECT * FROM `userinfo` WHERE userId IN ({arrOfUserIdString});", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var info = new UserInfo()
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
                

            MySqlCommand cmd = new MySqlCommand($"INSERT INTO `user` (name, surname) VALUES (\"{user.Name}\", \"{user.Surname}\");", connection);

            MySqlCommand command = new MySqlCommand("SELECT id FROM user ORDER BY id DESC LIMIT 1;", connection);
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

                cmd.CommandText += $"INSERT INTO `job` (userId, company, location, position) VALUES ({user.Job.UserId}, \"{user.Job.Company}\", \"{user.Job.Location}\", \"{user.Job.Position}\");";
            }

            if (user.UserInfo.Birthday != new DateTime() || user.UserInfo.someInfo != null)
            {
                user.UserInfo.UserId = TempUser.Id;

                cmd.CommandText += $"INSERT INTO `userinfo` (userId, birthday, someinfo) VALUES ({user.UserInfo.UserId}, \"{user.UserInfo.Birthday.ToString("yyy-M-d")}\", \"{user.UserInfo.someInfo}\");";
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
                MySqlCommand cmd = new MySqlCommand($"SELECT user.id, user.name, user.surname, " +
                    $"job.company, job.location, job.position, userinfo.birthday, userinfo.someinfo FROM `user` " +
                    $"INNER JOIN `job` ON job.userId = user.id " +
                    $"INNER JOIN `userinfo` ON userinfo.userId = user.id where user.id = {id}", connection);

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
                TempData["Message"] = "Date is uncorrect.";
                return View(user);
            }
                
            if (user.Name != "" || user.Surname != "")
            {
                cmd.CommandText += $"UPDATE user SET `name` = \"{user.Name}\", `surname` = \"{user.Surname}\" WHERE id = {user.Id}; ";
            }
            #endregion

            #region Update job table
            if (user.Job.Company != "" || user.Job.Location != "" || user.Job.Position != "")
            {
                MySqlCommand command = new MySqlCommand($"SELECT userId FROM `job` WHERE userId = {user.Id};", connection);
                MySqlDataReader reader = command.ExecuteReader();

                Job userInfo = new Job();
                if (reader.Read())
                {
                    try
                    {
                        userInfo = new Job()
                        {
                            UserId = reader.GetInt32(0)
                        };
                    }
                    catch { }
                }
                reader.Close();
                if (userInfo.UserId != 0)
                {
                    cmd.CommandText += $"UPDATE job SET `company` = \"{user.Job.Company}\", `location`= \"{user.Job.Location}\", `position` = \"{user.Job.Position}\" WHERE userId = {user.Id};";
                }
                else
                {
                    cmd.CommandText += $"insert job(userId, company, location, position) values({user.Id}, \"{user.Job.Company}\", \"{user.Job.Location}\", \"{user.Job.Position}\");";
                }
            }
            #endregion

            #region Update userInfo table
            if (user.UserInfo.Birthday != new DateTime() || user.UserInfo.someInfo != "")
            {
                MySqlCommand command = new MySqlCommand($"SELECT userId FROM `userinfo` WHERE userId = {user.Id};", connection);
                MySqlDataReader reader = command.ExecuteReader();

                UserInfo userInfo = new UserInfo();
                if (reader.Read())
                {
                    try
                    {
                        userInfo = new UserInfo()
                        {
                            UserId = reader.GetInt32(0)
                        };
                    }
                    catch { }
                }
                reader.Close();
                if (userInfo.UserId != 0)
                {
                    cmd.CommandText += $"UPDATE userinfo SET `birthday` = \"{user.UserInfo.Birthday.ToString("yyy-M-d")}\", `someinfo`= \"{user.UserInfo.someInfo}\" WHERE userId = {user.Id};";
                }
                else
                {
                    cmd.CommandText += $"insert job(userId, birthday, someinfo) values({user.Id}, \"{user.UserInfo.Birthday.ToString("yyy-M-d")}\", \"{user.UserInfo.someInfo}\");";
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
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM user WHERE id = {id}; DELETE FROM job WHERE userId = {id}; DELETE FROM userinfo WHERE userId = {id};", connection);

            // Execute the command
            int rowsAffected = cmd.ExecuteNonQuery();

            // Add temp message
            TempData["Message"] = "Record deleted successfully.";

            // Redirect to the index action
            return RedirectToAction("Index");
        }
    }
}
