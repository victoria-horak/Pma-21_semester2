using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ProgramRedis.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramRedis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly string mysqlConnectionString = "server=localhost;database=sqldatabase;uid=root;password=4815162342;";
        private readonly string redisConnectionString = "localhost:6379";
        private readonly ConnectionMultiplexer redisConnection;

        public DataController()
        {
            redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var redisDb = redisConnection.GetDatabase();

            // Check if data exists in Redis cache
            var cachedData = await redisDb.StringGetAsync("allUsers");
            if (cachedData.HasValue)
            {
                // Return cached data
                var cachedResult = JsonConvert.DeserializeObject<List<User>>(cachedData);
                return Ok(cachedResult);
            }

            // Connect to MySQL database
            using var connection = new MySqlConnection(mysqlConnectionString);
            await connection.OpenAsync();

            // Query the database for the desired data
            using var command = new MySqlCommand(@"
        SELECT users_red.id, users_red.name, users_red.age, addresses_red.address, contacts_red.email, contacts_red.phone
        FROM users_red
        INNER JOIN addresses_red ON users_red.id = addresses_red.user_id
        INNER JOIN contacts_red ON users_red.id = contacts_red.user_id
    ", connection);

            using MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            var users = new List<User>();

            // Read data from the database and store it in Redis
            while (await reader.ReadAsync())
            {
                var user = new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Age = reader.GetInt32(2),
                    Address = reader.GetString(3),
                    Email = reader.GetString(4),
                    Phone = reader.GetString(5)
                };
                var userJson = JsonConvert.SerializeObject(user);
                await redisDb.StringSetAsync($"user:{user.Id}", userJson);
                users.Add(user);
            }

            // Cache the retrieved data for all users in Redis
            await redisDb.StringSetAsync("allUsers", JsonConvert.SerializeObject(users), TimeSpan.FromMinutes(5));

            return Ok(users);
        }
    }
}
