using MySql.Data.MySqlClient;
using SQL_RedisUser.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace SQL_RedisUser
{
    public class DbServises
    {
        private static ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect("localhost:6379");
        public static List<User> GetUsersFromSqlDb()
        {
            var result = new List<User>();

            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";
            MySqlConnection connection = new MySqlConnection(connectionString);
            var mysqlCommand = connection.CreateCommand();
            mysqlCommand.CommandText = "SELECT U.userId, U.userName, U.age, UHC.city, UHC.street, UHC.building, UP.name, UP.animal FROM redis_schema.user as U left join redis_schema.address AS UHC on U.userId = UHC.userId left join redis_schema.pet AS UP on U.userId = UP.userId;";
            connection.Open();

            var dataReader = mysqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                var person = new User()
                {
                    UserId = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                    Age = dataReader.GetInt32(2),
                    HomeAddress = new Address()
                    {
                        City = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3),
                        Street = dataReader.IsDBNull(4) ? "" : dataReader.GetString(4),
                        Building = dataReader.IsDBNull(5) ? 0 : dataReader.GetInt32(5)
                    },
                    UserPet = new Pet()
                    {
                        Name = dataReader.IsDBNull(6) ? "" : dataReader.GetString(6),
                        Animal = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7)
                    }
                };
                result.Add(person);
                AddUserToRedis(person);
            }
            connection.Close();
            return result;
        }
        public static User AddUserToSqlDbAndRedisDb(User user)
        {
            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";
            MySqlConnection connection = new MySqlConnection(connectionString);
            var mysqlCommand = connection.CreateCommand();

            mysqlCommand.CommandText = $"INSERT INTO `redis_schema`.`user` (`userName`, `age`) VALUES ('{user.Name}', '{user.Age}'); Select max(userid) from redis_schema.user; ";

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
            insertCityCommand.CommandText = $"INSERT INTO `redis_schema`.`address` (`userid`, `city`, `street`,`building`) VALUES ('{newUserId}', '{user.HomeAddress.City}', '{user.HomeAddress.Street}','{user.HomeAddress.Building}');";
            insertCityCommand.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            var insertPetCommand = connection.CreateCommand();
            insertPetCommand.CommandText = $"INSERT INTO `redis_schema`.`pet` (`userid`, `name`,`animal`) VALUES ('{newUserId}', '{user.UserPet.Name}','{user.UserPet.Animal}');";
            insertPetCommand.ExecuteNonQuery();
            connection.Close();

            user.UserId = newUserId;
            AddUserToRedis(user);
            return user;
        }
        public static List<User> GetUsersFromRedis()
        {
            var redisDb = redisConnection.GetDatabase();
            var users = new List<User>();
            var keys = redisConnection.GetServer("localhost:6379").Keys();

            foreach (var key in keys)
            {
                if (key.ToString().Contains("UserSqlRedis"))
                {
                    try
                    {
                        var user = JsonSerializer.Deserialize<User>(redisDb.StringGet(key));
                        users.Add(user);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Not a user.");
                }
            }
            return users;
        }
        private static void AddUserToRedis(User user)
        {
            var redisDb = redisConnection.GetDatabase();
            var newKey = $"UserSqlRedis:{user.UserId}";
            string userToAdd = JsonSerializer.Serialize(user);
            redisDb.StringSet(newKey, userToAdd, TimeSpan.FromSeconds(300));
        }
        public static User GetUserByIdFromRedis(int id)
        {
            var key = $"UserSqlRedis:{id}";
            var db = redisConnection.GetDatabase();
            var keyExists = db.KeyExists(key);
            if (keyExists)
            {
                var redisUserValue = db.StringGet(key);
                return JsonSerializer.Deserialize<User>(redisUserValue);
            }
            return null;
        }
        public static User GetUserByIdFromSql(int id)
        {
            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";
            MySqlConnection connection = new MySqlConnection(connectionString);
            var mysqlCommand = connection.CreateCommand();
            mysqlCommand.CommandText = $"SELECT U.userId, U.userName, U.age, UHC.city, UHC.street, UHC.building, UP.name, UP.animal FROM redis_schema.user as U left join redis_schema.address AS UHC on U.userId = UHC.userId left join redis_schema.pet AS UP on U.userId = UP.userId where U.userId={id};";
            connection.Open();

            var dataReader = mysqlCommand.ExecuteReader();
            User user = null;

            if (dataReader.Read())
            {
                var sqluser = new User()
                {
                    UserId = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                    Age = dataReader.GetInt32(2),
                    HomeAddress = new Address()
                    {
                        City = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3),
                        Street = dataReader.IsDBNull(4) ? "" : dataReader.GetString(4),
                        Building = dataReader.IsDBNull(5) ? 0 : dataReader.GetInt32(5)
                    },
                    UserPet = new Pet()
                    {
                        Name = dataReader.IsDBNull(6) ? "" : dataReader.GetString(6),
                        Animal = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7)
                    }
                };
                user = sqluser;
                AddUserToRedis(user);
            }
            connection.Close();
            return user;
        }
    }
}
