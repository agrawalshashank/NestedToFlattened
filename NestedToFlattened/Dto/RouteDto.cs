using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NestedToFlattened.Dto
{
    public class RouteDto
    {
        public string RouteName { get; set; }
        public List<StopDto> Stops { get; set; }
    }
}
