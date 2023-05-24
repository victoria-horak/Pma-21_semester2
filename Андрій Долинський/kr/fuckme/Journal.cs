using MongoDB.Bson.Serialization.Attributes;

namespace andrew.Models
{
    public class Journal
    {
        [BsonId]
        public int _id { get; set; }
        public string? JournalType { get; set; }

        public string? JournalTite { get; set; }
    }
}
