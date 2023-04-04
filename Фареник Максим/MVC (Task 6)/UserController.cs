using Dapper;
using Microsoft.AspNetCore.Mvc;
using Model_View_Controller.Models;
using MySqlConnector;

namespace Model_View_Controller.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly string _connectionString = "server=127.0.0.1;port=3306;user=root;password=4815162342;database=mvcdb";


        

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            using var connection = new MySqlConnection(_connectionString);
            var users = await connection.QueryAsync<UserModel>(@"
            SELECT users.id, users.name, users.email, orders.product, orders.amount, addresses.address
            FROM users
            LEFT JOIN orders ON users.id = orders.user_id
            LEFT JOIN addresses ON users.id = addresses.user_id");
            return Ok(users);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<UserModel>> Post(UserModel user)
        {
            using var connection = new MySqlConnection(_connectionString);
            var result = await connection.ExecuteAsync(@"
            INSERT INTO users (name, email) VALUES (@Name, @Email);
            INSERT INTO orders (user_id, product, amount) VALUES (LAST_INSERT_ID(), @Product, @Amount);
            INSERT INTO addresses (user_id, address) VALUES (LAST_INSERT_ID(), @Address);",
                new { user.Name, user.Email, user.Product, user.Amount, user.Address });
            if (result == 3) // Check if all three inserts succeeded
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserModel user)
        {
            using var connection = new MySqlConnection(_connectionString);
            var result = await connection.ExecuteAsync(@"
            UPDATE users SET name = @Name, email = @Email WHERE id = @Id;
            UPDATE orders SET product = @Product, amount = @Amount WHERE user_id = @Id;
            UPDATE addresses SET address = @Address WHERE user_id = @Id;",
                new { user.Name, user.Email, user.Product, user.Amount, user.Address, Id = id });
            if (result == 3) // Check if all three updates succeeded
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            var transaction = await connection.BeginTransactionAsync();
            try
            {
                await connection.ExecuteAsync("DELETE FROM orders WHERE user_id = @UserId", new { UserId = id }, transaction);
                await connection.ExecuteAsync("DELETE FROM addresses WHERE user_id = @UserId", new { UserId = id }, transaction);
                await connection.ExecuteAsync("DELETE FROM users WHERE id = @UserId", new { UserId = id }, transaction);

                await transaction.CommitAsync();

                return Ok();
            }
            catch
            {
                await transaction.RollbackAsync();
                return BadRequest();
            }
        }
    }
}
