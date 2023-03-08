using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using JsonLinq;
using JsonLinq.DTO;
using JsonLinq.Model;

public class Program
{
    public static void Main(string[] args)
    {
        string dataFileName = "data.json";
        string responseFileName = "response.json";
        string dateToFilterByStr = "2021-03-02T12:00:00.000Z";
        DateTime dateToFilterBy = DateTime.Parse(dateToFilterByStr);
        string jsonText = File.ReadAllText(@dataFileName);
        IEnumerable<AviaRestrictionMessage> dataFromJson = JsonSerializer.Deserialize<List<AviaRestrictionMessage>>(jsonText, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        IEnumerable<RestrictionMessage> dataMapped = dataFromJson.Select(entry => new Mapper(entry).Map()).ToList();
        IEnumerable<RestrictionMessage> filtered =
            from entry in dataMapped
            where entry.EffectiveFrom <= dateToFilterBy && dateToFilterBy <= entry.EffectiveTo
            select entry
        ;
        bool anyFiltered = filtered.Any();
        Console.WriteLine($"There were {(anyFiltered ? "some" : "none")} message(s) filtered");
        string jsonResponse = JsonSerializer.Serialize(filtered, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
        File.WriteAllText(responseFileName, jsonResponse);
        System.Console.WriteLine(jsonText);
        System.Console.WriteLine(jsonResponse);
    }
}