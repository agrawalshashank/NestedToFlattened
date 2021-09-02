using System.Collections.Generic;

namespace Core.Models
{
    public class Stop
    {
        public string StopName { get; set; }
        public List<ObjectDetails> Objects { get; set; }
    }
}