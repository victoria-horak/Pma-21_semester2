using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Transaction.Models;

namespace Transaction.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var allUsers = GetFromDataBase();
            return View(allUsers);
        }
        public IActionResult MoneyTransfer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MoneyTransfer(PersonModel user, int transfer1, int transfer2)
        {
            var transactionSuccessfully = false;
            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;

                        command.CommandText = $"SELECT * FROM transaction_schema.new_table WHERE id = {user.Id};";
                        var dataReader = command.ExecuteReader();

                        if (!dataReader.Read())
                        {
                            dataReader.Close();
                            transaction.Rollback();
                            return new JsonResult($"Error: User {user.Id} does not exist.");
                        }

                        dataReader.Close();

                        command.CommandText = $"UPDATE transaction_schema.new_table SET money = money - {transfer1} WHERE id = {user.Id};";
                        command.ExecuteNonQuery();

                        command.CommandText = $"UPDATE transaction_schema.new_table SET money = money - {transfer2} WHERE id = {user.Id};";
                        command.ExecuteNonQuery();

                        command.CommandText = $"SELECT money FROM transaction_schema.new_table WHERE id = {user.Id};";
                        var moneyResult = command.ExecuteScalar();

                        if (moneyResult != null && Convert.ToInt32(moneyResult) < 0)
                        {
                            transaction.Rollback();
                            return new JsonResult("Error: Insufficient funds.");
                        }

                        transaction.Commit();
                        transactionSuccessfully = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new JsonResult($"Error: {ex.Message}");
                    }
                }
            }

            if (transactionSuccessfully)
            {
                return View("Index", GetFromDataBase());
            }
            else
            {
                return new JsonResult("Error: Transaction failed.");
            }
        }

        private static List<PersonModel> GetFromDataBase()
        {
            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";
            MySqlConnection connection = new MySqlConnection(connectionString);
            var mysqlCommand = connection.CreateCommand();
            mysqlCommand.CommandText = "Select * from transaction_schema.new_table";
            connection.Open();

            var datareader = mysqlCommand.ExecuteReader();
            var result = new List<PersonModel>();

            while (datareader.Read())
            {
                var person = new PersonModel()
                {
                    Id = datareader.GetInt32(0),
                    Name = datareader.GetString(1),
                    Surname = datareader.GetString(2),
                    Money = datareader.GetInt32(3)
                };
                result.Add(person);
            }
            connection.Close();
            return result;
        }
    }
}
