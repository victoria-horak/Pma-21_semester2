using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using KontrolnaMongoSQL.Models;

namespace KontrolnaMongoSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class UserControllerBase : ControllerBase
    {
        protected abstract IEnumerable<UserCompany> GetUsersFromMongoDB();
        protected abstract IEnumerable<UserCompany> GetUsersFromMySQL();

        protected IEnumerable<UserCompany> MergeUsers(IEnumerable<UserCompany> usersFromMongoDB, IEnumerable<UserCompany> usersFromMySQL)
        {
            return usersFromMongoDB.Concat(usersFromMySQL).ToList();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var usersFromMongoDB = GetUsersFromMongoDB();
            var usersFromMySQL = GetUsersFromMySQL();

            var allUsers = MergeUsers(usersFromMongoDB, usersFromMySQL);
            using (var connection = new MySqlConnection("Server=localhost;Database=kontrolnadb;Uid=root;Pwd=4815162342;"))
            {

                connection.Open();

                foreach (var user in allUsers)
                {
                    var insertCommand = new MySqlCommand("INSERT INTO newuserssql (id, name, age, home_address, company_name, address, experience) VALUES (@id, @name, @age, @homeAddress, @companyName, @address, @experience)", connection);
                    insertCommand.Parameters.AddWithValue("@id", user.Id);
                    insertCommand.Parameters.AddWithValue("@name", user.Name);
                    insertCommand.Parameters.AddWithValue("@age", user.PersonalData.Age);
                    insertCommand.Parameters.AddWithValue("@homeAddress", user.PersonalData.HomeAddress);
                    insertCommand.Parameters.AddWithValue("@companyName", user.WorkData.CompanyName);
                    insertCommand.Parameters.AddWithValue("@address", user.WorkData.Address);
                    insertCommand.Parameters.AddWithValue("@experience", user.WorkData.Experience);
                    insertCommand.ExecuteNonQuery();
                }
                connection.Close();
            }

            var json = JsonConvert.SerializeObject(allUsers, Formatting.Indented);
            return Ok(json);
        }

    }
    public class UserController : UserControllerBase
    {
        private readonly IMongoCollection<BsonDocument> _collection;
        private readonly MySqlConnection _mySqlConnection;

        public UserController()
        {
            // Підключення до MongoDB
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("kontrolna_robota");
            _collection = database.GetCollection<BsonDocument>("MongoUser");

            // Підключення до MySQL
            _mySqlConnection = new MySqlConnection("Server=localhost;Database=kontrolnadb;Uid=root;Pwd=4815162342;");
            _mySqlConnection.Open();
        }
        protected override IEnumerable<UserCompany> GetUsersFromMongoDB()
        {
            var users = new List<UserCompany>();

            var filter = new BsonDocument();
            var cursor = _collection.Find(filter);
            foreach (var document in cursor.ToEnumerable())
            {
                var id = document.GetValue("id").ToString();
                var name = document.GetValue("name").ToString();
                var age = document["Personal_data"]["age"].AsInt32;
                var homeAddress = document["Personal_data"]["home_address"].ToString();
                var companyName = document["Work_data"]["company_name"].ToString();
                var address = document["Work_data"]["address"].ToString();
                var experience = document["Work_data"]["experience"].ToString();

                var userCompany = new UserCompany
                {
                    Id = id,
                    Name = name,
                    PersonalData = new PersonalData
                    {
                        Age = age,
                        HomeAddress = homeAddress
                    },
                    WorkData = new WorkData
                    {
                        CompanyName = companyName,
                        Address = address,
                        Experience = experience
                    }
                };
                users.Add(userCompany);
            }
            return users;
        }
        protected override IEnumerable<UserCompany> GetUsersFromMySQL()
        {
            var users = new List<UserCompany>();

            var command = new MySqlCommand("SELECT * FROM kontr_user JOIN kontr_company ON kontr_user.id = kontr_company.user_id", _mySqlConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetString("id");
                var name = reader.GetString("name");
                var age = reader.GetInt32("age");
                var homeAddress = reader.GetString("home_address");
                var companyName = reader.GetString("company_name");
                var address = reader.GetString("address");
                var experience = reader.GetString("experience");

                var userCompany = new UserCompany
                {
                    Id = id,
                    Name = name,
                    PersonalData = new PersonalData
                    {
                        Age = age,
                        HomeAddress = homeAddress
                    },
                    WorkData = new WorkData
                    {
                        CompanyName = companyName,
                        Address = address,
                        Experience = experience
                    }
                };
                users.Add(userCompany);
            }

            reader.Close();
            _mySqlConnection.Close();

            return users;
        }
    }
}