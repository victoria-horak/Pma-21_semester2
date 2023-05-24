using Microsoft.AspNetCore.Mvc;
using MVCUser.Models;
using MySql.Data.MySqlClient;

namespace MVCUser.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var allUsers = GetFromDataBase();
            return View(allUsers);
        }

        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(UserModel user)
        {
            var id = AddUserToDataBase(user);
            return View("Index", GetFromDataBase());
        }
       
        public IActionResult UpdateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUser(UserModel user)
        {
            var updateSucesfully = UpdateUserInDataBase(user);
            if(updateSucesfully==true)
            { 
                return View("Index", GetFromDataBase()); 
            }
            else
            {
                return new JsonResult($" Error : User {user.UserId} does not exist.");
            }            
        }

        private bool UpdateUserInDataBase(UserModel user)
        {
            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";
            MySqlConnection connection = new MySqlConnection(connectionString);

            var mysqlCommand = connection.CreateCommand();

            mysqlCommand.CommandText = $"SELECT * FROM new_schema.user where userid = {user.UserId};";

            connection.Open();
            var dataReader = mysqlCommand.ExecuteReader();            

            if (!dataReader.Read())
            {
                connection.Close();
                return false;
            }
            connection.Close();

            connection.Open();
            var updateUserCommand = connection.CreateCommand();
            updateUserCommand.CommandText = $"UPDATE new_schema.user SET name = '{user.Name}', age = '{user.Age}' WHERE (userId = {user.UserId});";
            updateUserCommand.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            var updateCityCommand = connection.CreateCommand();
            updateCityCommand.CommandText = $"UPDATE new_schema.userhomecity SET city = '{user.HomeCity}' WHERE (userid = {user.UserId});";
            updateCityCommand.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            var updatePetCommand = connection.CreateCommand();
            updatePetCommand.CommandText = $"UPDATE new_schema.userpet SET petName = '{user.UserPetName}' WHERE (userId = {user.UserId});";
            updatePetCommand.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        private int AddUserToDataBase(UserModel user)
        {
            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";
            MySqlConnection connection = new MySqlConnection(connectionString);
            var mysqlCommand = connection.CreateCommand();

            mysqlCommand.CommandText = $"INSERT INTO `new_schema`.`user` (`name`, `age`) VALUES ('{user.Name}', '{user.Age}'); Select max(userid) from new_schema.user;";

            connection.Open();
            var dataReader = mysqlCommand.ExecuteReader();
            var newUserId = 0;

            while (dataReader.Read())
            {
                newUserId = dataReader.GetInt32(0);
            }
            connection.Close();

            connection.Open();
            var insertCityCommand = connection.CreateCommand();
            insertCityCommand.CommandText = $"INSERT INTO `new_schema`.`userhomecity` (`userid`, `city`) VALUES ('{newUserId}', '{user.HomeCity}'); ";
            insertCityCommand.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            var insertPetCommand = connection.CreateCommand();
            insertPetCommand.CommandText = $"INSERT INTO `new_schema`.`userpet` (`userid`, `petname`) VALUES ('{newUserId}', '{user.UserPetName}'); ";
            insertPetCommand.ExecuteNonQuery();
            connection.Close();

            return newUserId;
        }

        private List<UserModel> GetFromDataBase()
        {
            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";
            MySqlConnection connection = new MySqlConnection(connectionString);
            var mysqlCommand = connection.CreateCommand();
            mysqlCommand.CommandText = "SELECT U.userId, U.name, U.age, UHC.city, UP.petName FROM new_schema.user as U left join new_schema.userHomeCity AS UHC on U.userId = UHC.userId left join new_schema.userpet AS UP on U.userId = UP.userId ";
            connection.Open();

            var dataReader = mysqlCommand.ExecuteReader();
            var result = new List<UserModel>();

            while (dataReader.Read())
            {
                var person = new UserModel()
                {
                    UserId = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                    Age = dataReader.GetInt32(2),
                    HomeCity = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3),
                    UserPetName = dataReader.IsDBNull(4) ? "" : dataReader.GetString(4),
                };
                result.Add(person);
            }
            connection.Close();
            return result;
        }
    }
}
