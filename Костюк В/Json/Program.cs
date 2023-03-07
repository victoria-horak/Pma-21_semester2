using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;

namespace json_read_new
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("file.json");
            string output = "jsonOutput.json";

            List<User> users= new List<User>();
            JArray jsonArray = JArray.Parse(json);
            foreach (JObject item in jsonArray)
            {
                User currUser = new User();
                currUser.identificatorId = (string)item["identificatorId"];
                currUser.effectiveFrom = DateTime.Parse((string)item["dataItem"]["effectimeFrom"]);
                currUser.effectiveTo = DateTime.Parse((string)item["dataItem"]["effectiveTo"]);

                users.Add(currUser);
            }
            var dateToCheck = DateTime.Parse(File.ReadAllText("dataToCheck.txt"));         
            var thoseWhoFit = from user in users
                              where user.effectiveFrom <= dateToCheck &&
                                    user.effectiveTo >= dateToCheck
                              select user;

            foreach (User curr in thoseWhoFit)
            {
                Console.WriteLine(curr);
                File.WriteAllText(output, JsonConvert.SerializeObject(thoseWhoFit, Formatting.Indented));
            }
            Console.ReadKey();
        }
    }
}
