using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LinQJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileDataJson = @"C:\Users\Lily\source\repos\LinQJson\LinQJson\file.json";
            string fileDate = @"C:\Users\Lily\source\repos\LinQJson\LinQJson\date.txt";
            string fileToWrite = @"C:\Users\Lily\source\repos\LinQJson\LinQJson\writeTo.json";
            DateTime dateToCheck = DateTime.Parse(File.ReadAllText(fileDate));
            var objects = JsonConvert.DeserializeObject<List<AllInfo>>(File.ReadAllText(fileDataJson));
            var userObjects = from user in objects
                              where DateTime.Parse(user.dataItem.effectimeFrom) <= dateToCheck &&
                                    DateTime.Parse(user.dataItem.effectiveTo) >= dateToCheck
                              select new InfoImpotant
                              {
                                  identificatorId = user.identificatorId,
                                  objectId = user.dataItem.objectId,
                                  effectiveTo = DateTime.Parse(user.dataItem.effectiveTo),
                                  effectimeFrom = DateTime.Parse(user.dataItem.effectimeFrom),
                                  type = user.info.type
                              };
            foreach (var i in userObjects)
            {
                Console.WriteLine(i.ToString());
            }
            File.WriteAllText(fileToWrite, JsonConvert.SerializeObject(userObjects, Formatting.Indented));
        }
    }
}