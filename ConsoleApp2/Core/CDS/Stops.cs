using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotStop.Core.CDS
{
    class Stops
    {
        public int Id { get; set; }
        public string[] StopStart { get; set; }
        public string StopEnd { get; set; }
        public int SideCount { get; set; }

        public Stops(int Id, string[] StopStart, string StopEnd, int SideCount)
        {
            this.Id = Id;
            this.StopStart = StopStart;
            this.StopEnd = StopEnd;
            this.SideCount = SideCount;
        }
    }
}
