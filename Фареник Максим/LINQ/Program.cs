using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstFile = @"D:\C# projects\file.json";
            string information = File.ReadAllText(firstFile);

            string fileToWrite = @"D:\C# projects\output.json";
            string date = @"D:\C# projects\date.txt";
            var dateCheck = DateTime.Parse(File.ReadAllText(date));
        
            var documents = JsonConvert.DeserializeObject<List<Document>>(information).Select(element => new Adapter(element).Adapting()).Where(element => element.effectiveFrom <= dateCheck && element.effectiveTo >= dateCheck);
         
            foreach (var iterator in documents)
            {
                Console.WriteLine(iterator.ToString()+"\n");     
            }

            File.WriteAllText(fileToWrite, JsonConvert.SerializeObject(documents));
        }
    }
}
