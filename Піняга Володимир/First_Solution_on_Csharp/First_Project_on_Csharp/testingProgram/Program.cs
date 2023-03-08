using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace testingProgram
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            string root = @"C:\Users\user\Desktop\file.json";
            string write_root = @"C:\Users\user\Desktop\file_write.json";
            string dateRoot = @"C:\\Users\\user\\Desktop\date.txt";
            
            //Console.WriteLine(dateRoot);
            //Console.WriteLine("=============================");
            //string dateRoot = "2018-01-01T01:21:01.073876Z";

            var dateToCheck = DateTime.Parse(File.ReadAllText(dateRoot));
            //Console.WriteLine(dateToCheck);
            //Console.WriteLine("=============================");

            string text = File.ReadAllText(root);
            //Console.WriteLine(text);
            //Console.WriteLine("=============================");

            var array_of_objects = JsonConvert.DeserializeObject<List<Root>>(text).
                Select(_ => new Adapter(_).Adapt()).
                Where(_ => _.effectiveTo >= dateToCheck && _.effectiveFrom <= dateToCheck);

            array_of_objects = (from iterator in array_of_objects where iterator.effectiveFrom <= dateToCheck 
                                && iterator.effectiveTo >= dateToCheck
                             select iterator).ToList();

            foreach (var iterator in array_of_objects)
            {
                Console.WriteLine(iterator.ToString());
                Console.WriteLine("=============================");
            }

                //запис у файл 
            File.WriteAllText(write_root, JsonConvert.SerializeObject(array_of_objects, Formatting.Indented));
        }
    }
}