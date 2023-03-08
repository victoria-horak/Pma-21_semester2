using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_LINQ
{
    internal class Generateinput
    {
        public static void GenerateItemList()
        {
            var itemList = new List<Item>();

            for (int i = 0; i < 30; i++)
            {
                var random = new Random();
                var n = random.Next(10);
                var today = DateTime.UtcNow;

                var dataitem = new DataItem()
                {
                    objectId = i + 1,
                    effectimeFrom = today.AddYears(-n),
                    effectiveTo = today.AddYears(n),
                    someUsefullStuff = $"usefull stuff {i}:{n}",
                    someUselessStuff = $"useless stuff {i}:{n}",
                    stuff = $"some stuff {i}:{n}"
                };
                var info = new Info()
                {
                    twoUselessFields = $"useless field {i}:{n}",
                    currentFrom = today.AddYears(-2 * n),
                    currentAt = today.AddYears(2 * n),
                    type = $"type field {i}:{n}",
                    subInfo1 = $"sub info1 {i}:{n}",
                    subInfo2 = $"sub info2 field {i}:{n}",
                    subInfo3 = $"sub info3 field {i}:{n}"
                };
                var item = new Item()
                {
                    identificatorId = i,
                    dataItem = dataitem,
                    info = info,
                };
                itemList.Add(item);
            }
            var serializeList = JsonConvert.SerializeObject(itemList, Formatting.Indented);
            Console.WriteLine(serializeList.ToString());
        }
    }
}
