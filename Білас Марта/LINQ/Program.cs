using System;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("file.json");
            List<SomeObject> data = JsonConvert.DeserializeObject<List<SomeObject>>(text);
            foreach(SomeObject ob in data)
            {
                Console.WriteLine(ob.identificatorId);
                Console.WriteLine(ob.dataItem.objectId);
                Console.WriteLine(ob.dataItem.effectimeFrom);
                Console.WriteLine(ob.dataItem.effectiveTo);
            }
            Console.WriteLine();
            DateTime dt = DateTime.Parse(File.ReadAllText("data.txt"));
            var corrrectData = from myObject in data
                               where myObject.dataItem.effectimeFrom <= dt && myObject.dataItem.effectiveTo >= dt
                               select myObject;
            foreach(var ob in corrrectData)
            {
                Console.WriteLine(ob.identificatorId);
                Console.WriteLine(ob.dataItem.objectId);
                Console.WriteLine(ob.dataItem.effectimeFrom);
                Console.WriteLine(ob.dataItem.effectiveTo);
            }
        }
    }
}
