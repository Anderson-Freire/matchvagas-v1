
using NetTopologySuite.Geometries;

namespace src.Modules.Entities
{
    public class Location : BaseEntity
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public Point Coordinates { get; set; }
    }
}