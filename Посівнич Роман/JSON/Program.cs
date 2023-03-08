using Newtonsoft.Json;
using JSON_LINQ;
using System.ComponentModel.DataAnnotations;

string datepath = @"C:\Users\posiv\source\repos\ConsoleApp1\JSON_LINQ\DataInput\Data.txt";
var datefile = File.ReadAllText(datepath);
var dateToCompare = DateTime.Parse(datefile);

string path = @"C:\Users\posiv\source\repos\ConsoleApp1\JSON_LINQ\DataInput\Input.json";
var datafile = File.ReadAllText(path);
var allItemsFromFile = JsonConvert.DeserializeObject<List<Item>>(datafile);
//filtering original List
var fileredItems = allItemsFromFile.Where(item => item.dataItem.effectimeFrom <= dateToCompare && item.dataItem.effectiveTo >= dateToCompare);

//filtering and transforming without use of adapter 
var filteredItems2 = (from x in allItemsFromFile
                      where x.dataItem.effectimeFrom <= dateToCompare && x.dataItem.effectiveTo >= dateToCompare
                      select new TransformedItem()
                      {
                          effectiveTo = x.dataItem.effectiveTo,
                          effectimeFrom = x.dataItem.effectimeFrom,
                          type = x.info.type,
                          subInfo1 = x.info.subInfo1,
                          identificatorId = x.identificatorId
                      }
                      ).ToList();
//transforming all items
var adaptedItems = allItemsFromFile.Select(x => new Adapter(x).AdaptItem());
//filtering tranforming items 
var filteredTransformedItems = (from item in adaptedItems
                                where item.effectimeFrom <= dateToCompare && item.effectiveTo >= dateToCompare
                                select item)
                                .ToList();
string outputpath = @"C:\Users\posiv\source\repos\ConsoleApp1\JSON_LINQ\DataInput\Output.json";
var filteredItemsSeries = JsonConvert.SerializeObject(filteredTransformedItems,Formatting.Indented);
File.WriteAllText(outputpath, filteredItemsSeries);
Console.WriteLine(filteredItemsSeries);