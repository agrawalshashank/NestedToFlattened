using System.Collections.Generic;

namespace Core.Models
{
    public class Route
    {
        public string RouteName { get; set; }
        public List<Stop> Stops { get; set; }
    }
}
