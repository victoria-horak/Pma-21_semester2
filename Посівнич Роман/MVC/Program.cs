using MySql.Data.MySqlClient;
using System;

namespace MVCTest2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/all", () => GetFromDataBase());
            app.MapGet("/find/{surname}", (string surname) => GetBySurname(surname));
            app.MapGet("/findLinq/{surname}", (string surname) => GetFromDataBase().Where(x=>x.surname==surname).ToList());
            app.Run();
        }
        private static List<Person> GetFromDataBase()
        {
            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";
            MySqlConnection connection = new MySqlConnection(connectionString);
            var mysqlCommand = connection.CreateCommand();
            mysqlCommand.CommandText = "Select * from new_schema.person";
            connection.Open();

            var datareader = mysqlCommand.ExecuteReader();
            var result = new List<Person>();

            while (datareader.Read())
            {
                var person = new Person()
                {
                    personID = datareader.GetInt32(0),
                    surname = datareader.GetString(1),
                    name = datareader.GetString(2),
                    age = datareader.GetInt32(3)
                };
                result.Add(person);
            }
            connection.Close();
            return result;
        }
        private static List<Person> GetBySurname(string surnameToFind)
        {
            var connectionString = "database=mysql;datasource=localhost;user=root;password=1234";
            MySqlConnection connection = new MySqlConnection(connectionString);
            var mysqlCommand = connection.CreateCommand();
            mysqlCommand.CommandText = $"Select * from new_schema.person where surname = '{surnameToFind}'";
            connection.Open();

            var datareader = mysqlCommand.ExecuteReader();
            var result = new List<Person>();

            while (datareader.Read())
            {
                var person = new Person()
                {
                    personID = datareader.GetInt32(0),
                    surname = datareader.GetString(1),
                    name = datareader.GetString(2),
                    age = datareader.GetInt32(3)
                };
                result.Add(person);
            }
            connection.Close();
            return result;
        }
    }
}