using System.Collections.Generic;

namespace JsonLinq.DTO
{
    public class Info
    {
        public string Type { get; set; }
        public int MinFlightLevel { get; set; }
        public int MaxFlightLevel { get; set; }
        public List<Coordinate> Coordinates { get; set; }
        public string Reason { get; set; }
    }
}