using ClientWebAPI.Infrastructure;
using inClass.Models;
using Microsoft.AspNetCore.Mvc;
using multitableDataBase.Services;
using System.Data;
using System.Xml.Linq;
//using System.Reflection.Metadata.Ecma335;
//using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace inClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDb appDb;
        private readonly IUserService _userService;

        public UserController(AppDb db, IUserService userService)
        {
            appDb = db;
            _userService = userService;
        }


        [HttpGet("Users")]
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }


        [HttpGet("getUserbyName")]
        public async Task<List<User>> GetAllUsersWithSameNameAsync(string name)
        {
            var users = new List<User>();

            appDb.Connection.Open();
            using var command = appDb.Connection.CreateCommand();
            command.CommandText = @"SELECT 
                    users_data.id, 
                    users_data.first_name, 
                    users_data.last_name,
                    users_info.user_id,
                    users_info.email, 
                    users_info.living_country, 
                    users_phone.phone 
                FROM users_data 
                    INNER JOIN  users_info ON users_data.id = users_info.user_id 
                    INNER JOIN  users_phone ON users_info.id = users_phone.user_info_id
                WHERE first_name =@name";

            command.Parameters.AddWithValue("@name", name);
            var reader = await command.ExecuteReaderAsync();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var user = new User()
                    {
                        Id = reader.GetInt32(0),
                        First_name = reader.GetString(1),
                        Last_name = reader.GetString(2),
                        Info = new UsersInfo()
                        {
                            UserId = reader.GetInt32(3),
                            Email = reader.GetString(4),
                            LivingCountry = reader.GetString(5),
                            Phone = new UsersPhone
                            {
                                Phone = reader.GetString(6)
                            }

                        }
                    };
                    users.Add(user);
                }
            }
            return users;
        }


        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser(int id)
        {
            appDb.Connection.Open();
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using var command = appDb.Connection.CreateCommand();
            command.CommandText = @"DELETE FROM users_phone 
                                        WHERE user_id =@id;
                                    DELETE FROM users_info
                                        WHERE user_id =@id;
                                    DELETE FROM users_data
                                        WHERE id = @id;";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            return Ok("Success");
        }

        [HttpPost("addUser")]
        public IActionResult PostUser([FromBody]User user)
        {
            appDb.Connection.Open();

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using var command = appDb.Connection.CreateCommand();

            command.CommandText = @"INSERT INTO users_data (first_name, last_name)" + "VALUES (@first_name, @last_name)";
            command.Parameters.AddWithValue("@first_name", user.First_name);
            command.Parameters.AddWithValue("@last_name", user.Last_name);
            command.ExecuteNonQuery();
            int lastId = (Int32)command.LastInsertedId;

            command.CommandText = "INSERT INTO users_info (user_id, email, living_country)" + "VALUES (@user_id, @email, @livingPlace)";
            command.Parameters.AddWithValue("@user_id", lastId);
            command.Parameters.AddWithValue("@email", user.Info.Email);
            command.Parameters.AddWithValue("@livingPlace", user.Info.LivingCountry);
            command.ExecuteNonQuery();
            lastId = (Int32)command.LastInsertedId;

            command.CommandText = "INSERT INTO users_phone (user_info_id, phone)" + "VALUES (@user_info_id, @phone)";
            command.Parameters.AddWithValue("@phone", user.Info.Phone.Phone);
            command.Parameters.AddWithValue("@user_info_id", lastId);
            command.ExecuteNonQuery();

            return Ok("Success");
        }

        [HttpGet("updateUser/{userId}")]
        public IActionResult Get(int userId)
        {
            appDb.Connection.Open();
            using var command = appDb.Connection.CreateCommand();
            command.CommandText = @"SELECT 
                    users_data.id, 
                    users_data.first_name, 
                    users_data.last_name,
                    users_info.user_id,
                    users_info.email, 
                    users_info.living_country, 
                    users_phone.phone 
                FROM users_data 
                    INNER JOIN  users_info ON users_data.id = users_info.user_id 
                    INNER JOIN  users_phone ON users_info.id = users_phone.user_info_id
                WHERE users_data.id =@userId";

            command.Parameters.AddWithValue("@userId", userId);
            var reader = command.ExecuteReader();
            var user = new User();
            using (reader)
            {
                while (reader.Read())
                {
                    user = new User()
                    {
                        Id = reader.GetInt32(0),
                        First_name = reader.GetString(1),
                        Last_name = reader.GetString(2),
                        Info = new UsersInfo()
                        {
                            UserId = reader.GetInt32(3),
                            Email = reader.GetString(4),
                            LivingCountry = reader.GetString(5),
                            Phone = new UsersPhone
                            {
                                Phone = reader.GetString(6)
                            }

                        }
                    };
                }
            }
            return new JsonResult(user);
        }

        [HttpPut("updateUser/{userId}")]
        public IActionResult PutUser(int userId, [FromBody]User user)
        {
            appDb.Connection.Open();
            if (userId <= 0)
                return BadRequest("Not a valid student id");
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using var command = appDb.Connection.CreateCommand();
            command.CommandText = @"UPDATE users_data 
                                        SET first_name = @first_name,
                                        last_name = @last_name 
                                    WHERE id = @id";
            command.Parameters.AddWithValue("@id", userId);
            command.Parameters.AddWithValue("@first_name", user.First_name);
            command.Parameters.AddWithValue("@last_name", user.Last_name);
            command.ExecuteNonQuery();

            command.CommandText = @"UPDATE users_info
                                        SET email = @email, 
                                        living_country = @living_country
                                    WHERE user_id = @user_id";
            command.Parameters.AddWithValue("@user_id", userId);
            command.Parameters.AddWithValue("@email", user.Info.Email);
            command.Parameters.AddWithValue("@living_country", user.Info.LivingCountry);
            command.ExecuteNonQuery();


            command.CommandText = @"UPDATE users_phone
                                        SET phone = @phone
                                    WHERE user_info_id = @user_info_id";
            command.Parameters.AddWithValue("@phone", user.Info.Phone.Phone);
            command.Parameters.AddWithValue("@user_info_id", user.Info.UserId);
            command.ExecuteNonQuery();

            return Ok("Success");
        }
    }
}
