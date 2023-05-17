using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Redis_Task
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly string mysqlConnectionString = "server=localhost;database=sqldatabase;uid=root;password=4815162342;";
        private readonly string redisConnectionString = "localhost:6379";
        private readonly ConnectionMultiplexer redisConnection;

        private readonly IConnectionMultiplexer _redisConnection;

        public RedisController(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
        }

        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            IDatabase redisDb = _redisConnection.GetDatabase();

            string value = redisDb.StringGet(key);

            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPost("{key}")]
        public IActionResult Post(string key, [FromBody] string value)
        {
            IDatabase redisDb = _redisConnection.GetDatabase();

            bool success = redisDb.StringSet(key, value);

            if (!success)
            {
                return BadRequest("Failed to write data to Redis.");
            }

            return Ok("Data written to Redis successfully.");
        }

        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            IDatabase redisDb = _redisConnection.GetDatabase();

            bool success = redisDb.KeyDelete(key);

            if (!success)
            {
                return NotFound("Data not found in Redis.");
            }

            return Ok("Data deleted from Redis successfully.");
        }

    }
}
