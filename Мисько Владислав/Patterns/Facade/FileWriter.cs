namespace DesignPattern_Facade
{
    public static class FileWriter
    {
        public static void WriteToFile(object content, string path)
        {
            File.WriteAllText(path, SerializeText(content));
        }

        public static string SerializeText(object content)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(content, Newtonsoft.Json.Formatting.Indented);
        }

    }
}
