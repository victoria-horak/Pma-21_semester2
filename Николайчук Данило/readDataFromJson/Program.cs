using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using readDataFromJson;
using Newtonsoft.Json;

namespace readDataFromJson
{
    class Program
    {
        static void Main()
        {
            string path = "C:\\Users\\asd\\source\\C#\\University\\readDataFromJson\\readDataFromJson\\file.json";
            string text = File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<List<SomeObject>>(text);
            Console.WriteLine("All data:");
            foreach (var ob in data)
            {
                Console.WriteLine(ob.ToString());
            }
            Console.WriteLine("Data that is okey:");
            string datePath = @"C:\Users\asd\source\C#\University\readDataFromJson\readDataFromJson\TextFile1.txt";
            var dateToCheck = DateTime.Parse(File.ReadAllText(datePath));
            var newData = (from doc in data
                           where doc.effectimeFrom <= dateToCheck && doc.effectiveTo >= dateToCheck
                           select doc).ToList();

            foreach(var ob in newData) { Console.WriteLine(ob.ToString()); }
                         
        }
    }
}