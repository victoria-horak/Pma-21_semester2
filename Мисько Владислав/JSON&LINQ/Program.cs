using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\userPC\Downloads\Telegram Desktop\file.json";
            string path1 = @"C:\Users\userPC\Downloads\Telegram Desktop\file1.json";
            string datePath = @"D:\HomeworkC#\Task\date.txt";
            var dateToCheck = DateTime.Parse(File.ReadAllText(datePath));
            string content = File.ReadAllText(path);
            var documents = JsonConvert.DeserializeObject<List<ItemInfo>>(content).Select(_ => new Adapter(_).Adapt()).Where(_ => _.effectiveFrom <= dateToCheck && _.effectiveTo >= dateToCheck);
            documents = (from doc in documents
                           where doc.effectiveFrom <= dateToCheck && doc.effectiveTo >= dateToCheck
                           select doc).ToList(); 
            foreach (var doc in documents)
            {
                Console.WriteLine(doc.ToString());
                Console.WriteLine("-----------------");
            }
            File.WriteAllText(path1, JsonConvert.SerializeObject(documents, Formatting.Indented));
        }
    }
}
