using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;

namespace JsonTaskAttempt2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string datapath = @"C:\Users\Yura\RiderProjects\JsonTaskAttempt2\JsonTaskAttempt2\data.json";
            string datePath = @"C:\Users\Yura\RiderProjects\JsonTaskAttempt2\JsonTaskAttempt2\data.txt";
            string json_to_write = @"C:\Users\Yura\RiderProjects\JsonTaskAttempt2\JsonTaskAttempt2\write_to_json.json";
            var dateToCheck = DateTime.Parse(File.ReadAllText(datePath));

            string content = File.ReadAllText(datapath);

            var documents = JsonConvert.DeserializeObject<List<Root>>(content);
            var userObjects = from user in documents
                where DateTime.Parse(user.dataItem.effectimeFrom) <= dateToCheck &&
                      DateTime.Parse(user.dataItem.effectiveTo) >= dateToCheck
                select new RootImportant
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
            File.WriteAllText(json_to_write, JsonConvert.SerializeObject(userObjects, Formatting.Indented));
        }
    }
}