
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Prototype
{
    static class ExtentionMethod
    {
        public static T DeepCopy<T>(this T self)
        {
            if (ReferenceEquals(self, null))// Якщо селф == null
            {
                return default(T);
            }
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream()) //потік всередині пам'яті, де ми будемо записувати дані
            {
                formatter.Serialize(stream, self); // Serialization is the process of converting an object into a stream of bytes to store the object or transmit it to memory, a database, or a file. Its main purpose is to save the state of an object in order to be able to recreate it when needed. The reverse process is called deserialization
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
