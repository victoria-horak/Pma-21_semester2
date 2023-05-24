using Microsoft.AspNetCore.Mvc;
using SQL_RedisUser.Models;

namespace SQL_RedisUser.Controllers
{
    public class UserController : Controller
    {
       public List<User> GetAllUsers()
        {
            return DbServises.GetUsersFromSqlDb();
        }
        [HttpPost]
        public User AddUser([FromBody] User user) 
        {
            return DbServises.AddUserToSqlDbAndRedisDb(user);
        }
        public List<User> GetUsersFromRedis() 
        {
            return DbServises.GetUsersFromRedis();
        }
        public User GetUserFromRedis(int id) 
        {
            return DbServises.GetUserByIdFromRedis(id);
        }
        public User GetUserById(int id)
        {
            return DbServises.GetUserByIdFromSql(id);
        }
    }
}
