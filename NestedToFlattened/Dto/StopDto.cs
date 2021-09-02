using System.Collections.Generic;

namespace NestedToFlattened.Dto
{
    public class StopDto
    {
        public string StopName { get; set; }
        public List<ObjectDto> Objects { get; set; }
    }
}