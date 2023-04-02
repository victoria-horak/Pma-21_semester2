using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.Json;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select UserId,UserName,UserLastName from mytestdb.MyUser";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();

                }
            }
            return new JsonResult(table);
        }

        [HttpGet("{name}")]
        public JsonResult Get(string name)
        {
            string query = $"select UserId, UserName, UserLastName from mytestdb.MyUser where UserName like '%{name}%'";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();

                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Insert(User user)
        {
            string query = $"INSERT INTO mytestdb.MyUser (UserName, UserLastName) VALUES('{user.UserName}', '{user.UserLastName}')";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("User added successfully");
        }
        [HttpPut("{id}")]
        public JsonResult UpdateUser(int id, User user)
        {
            string query = $"UPDATE mytestdb.MyUser SET UserName='{user.UserName}', UserLastName='{user.UserLastName}' WHERE UserId={id}";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("User updated successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = $"DELETE FROM mytestdb.MyUser WHERE UserId={id}";

            string updateQuery = $"SET @cnt = 0; UPDATE mytestdb.MyUser SET UserId = @cnt:= @cnt + 1 WHERE UserId > {id}; ALTER TABLE mytestdb.MyUser AUTO_INCREMENT = @cnt;";

            string sqlDataSource = _configuration.GetConnectionString("MyConnection");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {
                    mycommand.ExecuteNonQuery();
                }
                mycon.Close();
            }

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, mycon))
                {
                    updateCommand.ExecuteNonQuery();
                }
                mycon.Close();
            }

            return new JsonResult("User deleted successfully");
        }
    }
}
