using System;

namespace JsonLinq.Model
{
    public class RestrictionMessage
    {
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public string PublishedInfo { get; set; }
        public string Reason { get; set; }
    }
}
