using System;

namespace JsonLinq.DTO
{
    public class DataItem
    {
        public int ObjectId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public string PublishedBy { get; set; }
        public string ReviewedBy { get; set; }
        public DateTime ReviewedOn { get; set; }
    }
}
