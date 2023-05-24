using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;


namespace TransactionsProgram.Controllers
{
    public class UserController : ControllerBase
    {
        string connectionString = "server=localhost;database=transdb;uid=root;password=4815162342;";

        [HttpPost("api/user/transfermoney")]

        public IActionResult TransferMoney(int from, int to, double amount)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;

                MySqlTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "UPDATE users SET money = money - @amount WHERE id = @from";
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@from", from);
                    command.ExecuteNonQuery();

                    command.CommandText = "UPDATE users SET money = money + @toAmount WHERE id = @to";
                    command.Parameters.AddWithValue("@toAmount", amount);
                    command.Parameters.AddWithValue("@to", to);
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    return Ok();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    var exception = new { Message = ex.Message, StackTrace = ex.StackTrace };
                    return StatusCode(500, exception);
                }
            }
        }
    }
}