using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQwithJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string requiredData = @"C:Users\Dell\source\repos\LINQwithJSON\LINQwithJSON\input.json";
            string writeDate = @"C:Users\Dell\source\repos\LINQwithJSON\LINQwithJSON\ouput.json";
            string file = @"C:Users\Dell\source\repos\LINQwithJSON\LINQwithJSON\data.txt";
            // зчитуєм з файлу
            string dateToCheckString = File.ReadAllText(file);
            DateTime dateToCheck;
            bool isDateValid = DateTime.TryParse(dateToCheckString, out dateToCheck);

            if (!isDateValid)
            {
                Console.WriteLine("Дата є невірною.");
                return;
            }

            // Зчитуємо вміст файлу JSON і десеріалізуємо його у список об'єктів типу RequiredData
            string content = File.ReadAllText(requiredData);
            List<RequiredData> requiredDatas = JsonConvert.DeserializeObject<List<RequiredData>>(content);

            // Конвертуємо кожен об'єкт типу RequiredData у об'єкт типу Document
            List<Type> documents = new List<Type>();
            foreach (RequiredData i in requiredDatas)
            {
                Type document = new Adapter(i).Adapt();
                documents.Add(document);
            }

            // Фільтруємо список документів за заданою датою
            List<Type> filteredType = documents.Where(doc => doc.effectiveFrom <= dateToCheck && doc.effectiveTo >= dateToCheck).ToList();

            // Виводимо кожен документ у консоль та записуємо результати у файл JSON
            foreach (Type doc in filteredType)
            {
                Console.WriteLine(doc.ToString());
                Console.WriteLine("-----------------");
            }

            string output = JsonConvert.SerializeObject(filteredType, Formatting.Indented);
            File.WriteAllText(writeDate, output);
        }

    }
}
