using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonandLinq
{
    internal class Program
    {
        static void Main()
        {
            string json = @"C:\Users\User\source\repos\JsonandLinq\JsonandLinq\sources\Json.txt";
            string exampleDate = @"C:\Users\User\source\repos\JsonandLinq\JsonandLinq\sources\date.txt";
            string ourJsonText = File.ReadAllText(json);
            string writeInJson = "C:\\Users\\User\\source\\repos\\JsonandLinq\\JsonandLinq\\sources\\sorted.txt";
            
            DateTime auditData = Convert.ToDateTime("2018-11-07T00:25:00.073876Z");
            
            List<IdentificatorId> dataJson = JsonConvert.DeserializeObject<List<IdentificatorId>>(ourJsonText);
            Console.WriteLine("-------0utput of data read from json but not sorted by linQ------- : \n");
            
            foreach (IdentificatorId data in dataJson)
            {
                Adapter adapter = new Adapter(data);
                NewUnification newUnification = adapter.Adapt();
                Console.WriteLine(newUnification.Input());
                Console.WriteLine("_____________________________");

            }

            List<IdentificatorId> sortedDataJson = dataJson
                .Where(data => DateTime.Parse(data.dataItem.effectiveFrom) <= auditData && DateTime.Parse(data.dataItem.effectiveTo) >= auditData)
                .Select(data => data)
                .ToList();
            Console.WriteLine("-------We display the sorted list with the help of a linQ------- :\n");
            
            foreach (IdentificatorId data in sortedDataJson)
            {
                Adapter adapter = new Adapter(data);
                NewUnification newUnification = adapter.Adapt();
                Console.WriteLine(newUnification.Input());
                Console.WriteLine("_____________________________");
            }

            string jsonString = JsonConvert.SerializeObject(sortedDataJson, Formatting.Indented);
            File.WriteAllText(writeInJson, jsonString);

        }
    }
}
