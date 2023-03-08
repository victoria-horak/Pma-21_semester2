using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using LinQ;
using Newtonsoft.Json;

namespace JsonTaskAttempt2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dataRead = @"C:\Users\Mykola\RiderProjects\LinQ\LinQ\data.json";
            string dateFilter = @"C:\Users\Mykola\RiderProjects\LinQ\LinQ\dateFilter.txt";
            string dataWrite = @"C:\Users\Mykola\RiderProjects\LinQ\LinQ\dataWrite.json";
            var dateToFilter = DateTime.Parse(File.ReadAllText(dateFilter));
            var listDataAll = JsonConvert.DeserializeObject<List<DataAll>>(File.ReadAllText(dataRead));
            var listDataEssential = from data in listDataAll
                where DateTime.Parse(data.dataItem.effectimeFrom) <= dateToFilter &&
                      DateTime.Parse(data.dataItem.effectiveTo) >= dateToFilter
                select new DataAllToDataEssentialAdapter(data).ToDataEssential();
            foreach (var item in listDataEssential)
            {
                Console.WriteLine(item.ToString());
            }
            File.WriteAllText(dataWrite, JsonConvert.SerializeObject(listDataEssential, Formatting.Indented));
        }
    }
}